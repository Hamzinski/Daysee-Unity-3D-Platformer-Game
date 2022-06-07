using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openclose : MonoBehaviour
{
   public GameObject openmenu, closemenu;
   public void menuUI()
   {
       openmenu.SetActive(true);
       closemenu.SetActive(false);
   }

        
    
}
