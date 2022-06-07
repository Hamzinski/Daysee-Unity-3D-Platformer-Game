using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
  
    private float bounce = 20f;
    private void OnCollisionEnter (Collision collision)
    {
      if(collision.gameObject.CompareTag("Player"))
      {
          collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounce, ForceMode.Impulse);
      }
    }
}
