using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int numerador, denominador, cociente, resto, modo_juego, material_cubo;
    public static int contador_container_llenos=0;
    public GameObject[] thecubesmenu;
    public GameObject inputField_num, inputField_den, container;
    public Dropdown dropdown_modo, dropdown_cubo;
    public Renderer cubo;
    [SerializeField]
    Material frozenMaterial, spidermanMaterial, sirenitaMaterial, hulkMaterial, pepapigMaterial;
    private Material materialseleccionado;

    void Start(){}
    void Update(){}

    public void CargaNivel(){
        if(modo_juego==1)
            SceneManager.LoadScene("Juego");
        else
            SceneManager.LoadScene("Juego_1persona");
    }
    public void CargaMainMenu(){
        numerador = 0;
        denominador = 0;
        SceneManager.LoadScene("Menu");
        contador_container_llenos = 0;
         
    }
    public void CargaConfig(){
        SceneManager.LoadScene("Config");      
    }

    public void BackMenu(){
        SceneManager.LoadScene("Menu");      
    }

    public void StoreNum(){
        numerador = int.Parse(inputField_num.GetComponent<Text>().text);
        denominador = int.Parse(inputField_den.GetComponent<Text>().text);

        cociente = numerador / denominador;
        resto = numerador % denominador;
    }

    public void SetModoJuego(){
        modo_juego = dropdown_modo.value;
    }
    public void SetMaterialCubo(){
        material_cubo = dropdown_cubo.value;
        switch(material_cubo){
            case 0:
                cubo.material = spidermanMaterial;
                materialseleccionado = spidermanMaterial;
                break;
            case 1:
                cubo.material = frozenMaterial;
                materialseleccionado = frozenMaterial;
                break;
            case 2:
                cubo.material = pepapigMaterial;
                materialseleccionado = pepapigMaterial;
                break;
            case 3:
                cubo.material = hulkMaterial;
                materialseleccionado = hulkMaterial;
                break;
            case 4:
                cubo.material = sirenitaMaterial;
                materialseleccionado = sirenitaMaterial;
                break;
        }

        foreach(var obj in thecubesmenu){
             obj.GetComponent<Renderer>().sharedMaterial = materialseleccionado;
         }     
    }

    public void QuitGame(){
        Debug.Log("Quit!");
        Application.Quit();
    }

}
