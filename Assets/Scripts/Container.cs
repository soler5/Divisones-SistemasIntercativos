using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
 public class Container : MonoBehaviour
 {
     private Dictionary<Collider, bool> _triggerStates = new Dictionary<Collider, bool>();
     public List<Collider> _currentTriggers { get; private set; } = new List<Collider>();
     private bool _on = true;
     [SerializeField]
    Material selectedMaterial;


     // FixedUpdate is first in Unity's execution order.
     // We use it to check the state of the triggers we are currently colliding with.
     // To avoid iterating over the Dictionary, because then I can't remove from it while iterating,
     // I keep the equivalent of its keys in a list next to it. This might not be the most memory
     // efficient, until you realize that it doubles as a constantly up-to-date list of all
     // the colliders we are currently triggering, which is what we wanted to get this thing
     // to produce in the first place. Also, they'll just be references, some bools and some hashes.
     // We shouldn't be handling too many collisions like this, anyway.
     // You can easily create functions to turn it on and off, if you find it to be too intensive.

     private void FixedUpdate()
     {
         for (var i = 0; i < _currentTriggers.Count; i++)
         {
             var trigger = _currentTriggers[i];
             // If the trigger is no more, for whatever reason, remove it.
             if (!trigger)
             {
                 _triggerStates.Remove(trigger);
                 _currentTriggers.Remove(trigger);
                 continue;
             }
 
             // If _currentTriggers has a collider which _triggerStates doesn't have, something
             // weird has happened (it should not be possible), so default to scrapping it.
             // It'll get added again next FixedUpdate if it is still OnTriggerStay'ing.
             if (!_triggerStates.ContainsKey(trigger))
             {
                 _currentTriggers.Remove(trigger);
             }
             else
             {
                 // This is the exciting part. FixedUpdate runs before the OnTrigger***, so we can
                 // check here what the results are after the last OnTrigger*** calls came in.
                 // They all set the state to "true" when adding or stay'ing a trigger, so if its
                 // state is false here, then it is no longer stay'ing, and OnTriggerExit has not
                 // been called to remove it, so we do it here.
                 if (!_triggerStates[trigger])
                 {
                     _triggerStates.Remove(trigger);
                     _currentTriggers.Remove(trigger);
                 }
                 else
                 {
                     // Reset state to "false", so the coming OnTrigger*** calls can update them again.
                     _triggerStates[trigger] = false;
                 }
             }
         }
     }
 
     // Called when a trigger enters
     private void OnTriggerEnter(Collider other)
     {
        //Debug.Log("cociente; "+cociente);
        //Debug.Log("contador container; "+LevelManager.contador_container_llenos);
         //if the object is not already in the list
         if (!_triggerStates.ContainsKey(other) && other.tag != "tag_continer")
         {

             //add the object to the list
             _triggerStates.Add(other, true);
             _currentTriggers.Add(other);

             if(_currentTriggers.Count==LevelManager.cociente){
                 GetComponent<Renderer>().material = selectedMaterial;
                //Debug.Log("antes de incrementar; "+LevelManager.contador_container_llenos);
                 LevelManager.contador_container_llenos += 1;
             }else if(_currentTriggers.Count>LevelManager.cociente){
                //Debug.Log("antes de incrementar; "+LevelManager.contador_container_llenos);
                 LevelManager.contador_container_llenos -= 1;
                 //Debug.Log("despues de incrementar; "+LevelManager.contador_container_llenos);
                 GetComponent<Renderer>().material = default;
             }
         }

        if(LevelManager.contador_container_llenos==LevelManager.denominador){
            StartCoroutine(YouWin());
        }
     }
 
     // Called every FixedUpdate between OnTriggerEnter and OnTriggerExit (or until the trigger is
     // disabled, in which case OnTriggerExit is not called, which is why we're doing all of this ;) ).
     private void OnTriggerStay(Collider other)
     {
         if (!_triggerStates.ContainsKey(other) && other.tag != "tag_continer")
         {
             //add the object to the list
             _triggerStates.Add(other, true);
             _currentTriggers.Add(other);
         }
         else
         {
             _triggerStates[other] = true;
         }
     }
 
     // Called when a trigger exits.
     private void OnTriggerExit(Collider other)
     {
        _triggerStates.Remove(other);
        _currentTriggers.Remove(other);

        if(_currentTriggers.Count==LevelManager.cociente){
            LevelManager.contador_container_llenos++;
            GetComponent<Renderer>().material = selectedMaterial;

        }else if(_currentTriggers.Count + 1 == LevelManager.cociente && _currentTriggers.Count < LevelManager.cociente){
            GetComponent<Renderer>().material = default;
            LevelManager.contador_container_llenos--;
            Debug.Log("al salir: "+LevelManager.contador_container_llenos);
        }
     }
 
     public void ResetRegisteredTriggers()
     {
         _currentTriggers.Clear();
         _triggerStates.Clear();
     }
 
     public void Toggle(bool on, bool resetCurrentTriggers = true)
     {
         _on = on;
         if(resetCurrentTriggers)
             ResetRegisteredTriggers();
     }

     IEnumerator YouWin(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("You_Win");
     }
 }