using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class You_win : MonoBehaviour
{
    public Text finalText;
    public Text finalresulText;
    public Text restoText;

    // Start is called before the first frame update
    void Start(){
        finalText.text = "¡Muy bien!" + "\n" + "El resultado de la división "+ "\n" + LevelManager.numerador + " / "  +LevelManager.denominador +" es ";
        finalresulText.text = "" + LevelManager.cociente;
        restoText.text = "El resto es " + LevelManager.resto;
    }

    // Update is called once per frame
    void Update(){}
}
