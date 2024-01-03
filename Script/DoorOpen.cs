using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorOpen : MonoBehaviour {

    public GameObject info;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Panto")
        {
                info.SetActive (true);
                Animator anim = other.GetComponentInChildren<Animator>();
                if (Input.GetKeyDown (KeyCode.E))
                anim.SetTrigger ("BukaTutup");
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.tag == "Panto"){
            info.SetActive (false);
        }
    }
}
