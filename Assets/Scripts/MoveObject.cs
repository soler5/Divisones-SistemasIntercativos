using UnityEngine;
 
 public class MoveObject : MonoBehaviour {
     public SelectObject SelectObject;
     public float moveSpeed;

     private void Start() {
        this.SelectObject = FindObjectOfType<SelectObject>();
        moveSpeed = 5.5f;
     }
 
     private void Update() {
         if (this.SelectObject.SelectedObject == null) return;

         var vertical = Input.GetAxis("Vertical");
         var horizontal = Input.GetAxis("Horizontal");

         this.SelectObject.SelectedObject.transform.Translate(moveSpeed*horizontal*Time.deltaTime,0f,moveSpeed*vertical*Time.deltaTime); 
        
     }
 }