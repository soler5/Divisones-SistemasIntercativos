using UnityEngine;
 
 public class SelectObject : MonoBehaviour
 {
     public GameObject SelectedObject;
 
     private void Update()
     {
         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit raycastHit;
         if (!Physics.Raycast(ray, out raycastHit)) return;

         if ((raycastHit.collider.gameObject.tag == "Moveable") && Input.GetMouseButtonDown(0)){
            this.SelectedObject = raycastHit.collider.gameObject;
         } 
     }
 }