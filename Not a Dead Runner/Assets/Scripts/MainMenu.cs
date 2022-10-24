using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    // Start is called before the first frame update
   private void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
