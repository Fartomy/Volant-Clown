using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Anamenu : MonoBehaviour
{ 
    public Text highScoreText;
    public Text score;
    public int baslaTusuSayi = 0;
  
    void Start()
    {
        int highsCore = PlayerPrefs.GetInt("kayit");
        int skor = PlayerPrefs.GetInt("puankayit");
        highScoreText.text = "Highest Score! \n"+highsCore;
        score.text = "Your Score \n" + skor;
    }

   public void oyunBasla()
    {
        SceneManager.LoadScene("SampleScene");
    }

   public void oyunCik()
    {
        Application.Quit();
    }

}
