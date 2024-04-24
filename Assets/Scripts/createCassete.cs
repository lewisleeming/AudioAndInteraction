using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;

public class createCassete : MonoBehaviour
{

    [SerializeField] Transform spawn;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public string soundPath;
    public string audioName;
    public audioRecorder recorder;

    public playCassete cs;

    public GameObject cassete;
    
    public void getRecorderAudio(){
        audioSource = gameObject.GetComponent<AudioSource>();
        recorder = GameObject.Find("Main Camera").GetComponent<audioRecorder>();
        soundPath = "file://" + Application.streamingAssetsPath + "/Sound/";
        audioName = "lewishope"+recorder.randomNumber+".wav";
        StartCoroutine(LoadAudio());
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = true;
        if(audioSource.isPlaying == true){
            //cassete.GetComponent<playCassete>().clipaudio = audioClip;
            //Instantiate(cassete, new Vector3(0f,0f,0f), Quaternion.identity);
            cassete.GetComponent<playCassete>().clipaudio = audioClip;
            Instantiate(cassete, new Vector3(-0.5f,1f,0f), Quaternion.identity);
        }
    }

    private IEnumerator LoadAudio(){
        WWW request = getAudioFromFile(soundPath, audioName);
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = audioName;
    }

    private WWW getAudioFromFile(string path, string filename){
        string audioToLoad = string.Format(path + "{0}", filename);
        WWW request = new WWW(audioToLoad);
        return request;
    }

}