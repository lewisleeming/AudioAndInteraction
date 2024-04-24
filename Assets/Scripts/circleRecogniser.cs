using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using PDollarGestureRecognizer;
using System.IO;
using UnityEngine.Events;

public class circleRecogniser : MonoBehaviour
{

    [SerializeField] XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    public Transform movemementSource;

    private bool isMoving = false;

    public GameObject debugCubePrefab;
    private List<Vector3> positionsList = new List<Vector3>();
    public float newPositionDistance = 0.05f;

    public bool creationMode = true;
    public string newGestureName;

    public float recoginitionThreshold = 0.9f;

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> { }
    public UnityStringEvent OnRecognized;



    private List<Gesture> trainginSet = new List<Gesture>();


    // Start is called before the first frame update
    void Start()
    {
        string[] gestureFiles = Directory.GetFiles(Application.persistentDataPath, "*.xml");
        foreach (var item in gestureFiles)
        {
            trainginSet.Add(GestureIO.ReadGestureFromFile(item));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);

        if(!isMoving && isPressed)
        {
            StartMovement();

        }else if(isMoving && !isPressed){
            EndMovement();

        }else if(isMoving && isPressed){
            UpdateMovement();

        }

    }

    void StartMovement(){
        Debug.Log("Start Movement");
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movemementSource.position);
        Instantiate(debugCubePrefab,movemementSource.position, Quaternion.identity);
        isMoving = true;

        if(debugCubePrefab){
            Destroy(Instantiate(debugCubePrefab, movemementSource.position, Quaternion.identity),3);
        }

    }
    void EndMovement(){
        Debug.Log("end movement");
        isMoving = false;

        Point[] pointArray = new Point[positionsList.Count];
        for (int i = 0; i < positionsList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionsList[i]);
            pointArray[i] = new Point(screenPoint.x,screenPoint.y, 0);
        }
        Gesture newGesture = new Gesture(pointArray); 

        if(creationMode){
            newGesture.Name = newGestureName;
            trainginSet.Add(newGesture);

            string filename = Application.persistentDataPath + "/" + newGestureName + ".xml";
            GestureIO.WriteGesture(pointArray,newGestureName,filename);
        }else{
            Result result = PointCloudRecognizer.Classify(newGesture,trainginSet.ToArray());
            Debug.Log(result.GestureClass + result.Score);
            if(result.Score > recoginitionThreshold){
                OnRecognized.Invoke(result.GestureClass);
            }
        }
    }
    
    void UpdateMovement(){
        Debug.Log("update movement");
        Vector3 lastPosition = positionsList[positionsList.Count-1];
        if(Vector3.Distance(movemementSource.position,lastPosition) > newPositionDistance){
            positionsList.Add(movemementSource.position);
            if(debugCubePrefab){
            Destroy(Instantiate(debugCubePrefab, movemementSource.position, Quaternion.identity),3);
            }
        }
    }
}
