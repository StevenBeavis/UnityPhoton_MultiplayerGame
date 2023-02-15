using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerController : MonoBehaviourPun
{
    public float turnSpeed = 180;
    public float tiltSpeed = 180;
    public float walkSpeed = 1;

    [SerializeField]
    private Transform fpcam;

    public static int identity;

    PhotonView pv;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            float forward = Input.GetAxis("Vertical");
            float turn = Input.GetAxis("Horizontal");/* Input.GetAxis("Mouse X");*/
            float tilt = Input.GetAxis("Mouse Y");
            transform.Translate(new Vector3(0, 0, forward * walkSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, turn * turnSpeed * Time.deltaTime, 0));
            /*
            if (fpcam != null)
                fpcam.Rotate(new Vector3(-tilt * tiltSpeed * Time.deltaTime, 0));
            */
        }

        

        /*
        if (this.gameObject.tag == "Enemy")
        {
            health = 1000;
        }
        
        
        if (this.gameObject.tag == "Enemy")
        {

            if (Input.GetButtonDown("Fire1"))
            {
                TakeDamage();
            }
        }
        if (gameObject.tag == "InRange")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                TakeDamage();
            }
        }
        /
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Radius")
            {
                gameObject.tag = "InRange";
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Radius")
            {
                gameObject.tag = "Player";
            }
        }

        void TakeDamage()
        {
            health = health - 50;
        }*/
    }
}
