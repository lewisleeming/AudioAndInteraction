using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recordPlayer : MonoBehaviour
{
    public Animator animator;
    public GameObject casseteIn;

    public GameObject casseteReal;
    
    // Start is called before the first frame update
    void Start()
    {
        //casseteIn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("cass")){
            casseteReal = GameObject.Find(other.name);
            //casseteReal.SetActive(false);
            //Debug.Log(other.name);
            //casseteIn.SetActive(true);
            casseteReal.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            animator.SetTrigger("playCass");
            casseteReal.GetComponent<playCassete>().playNewCassete();
        }
    }
    

    public void ejectCassete(){
        casseteReal.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + 0.2f);
        //casseteReal.SetActive(true);
        casseteReal.GetComponent<playCassete>().stopCassete();
        animator.SetTrigger("removeCass");
        
    }


    
}
