using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
   [SerializeField] private GameObject myCube;
   public void RotateCubeRight()
   {
      myCube.transform.Rotate(Vector3.right * 5000);
   }

   public void RotateCubeUp()
   {
      myCube.transform.Rotate(Vector3.up * 5000);
   }

   public void RotateCubeLeft()
   {
      myCube.transform.Rotate(Vector3.left * 5000);
      myCube.SetActive(false);
   }
}
