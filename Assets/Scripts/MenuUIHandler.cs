using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        nameInput = GameObject.Find("Name Input").GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        PersistanceManager.Instance.playerName = nameInput.text;

        SceneManager.LoadScene(1);
    }
}
