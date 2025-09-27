using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CollectFruits : MonoBehaviour
{
    [SerializeField] AudioClip loosingSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip GetPoint;



    [SerializeField] TextMeshProUGUI CongGoodLuck;
    [SerializeField] TextMeshProUGUI winloose;
    [SerializeField] GameObject EndPanel;
    [SerializeField] GameObject[] Fruits;
    [SerializeField] Text Txt; //to dispay the sum of fruits(score) 
    [SerializeField] float speed = 2f;
    public int sum = 0;// sum of fruits
    public int[] s = new int[7];
    public int cherry, strawberry, lemon, banana, pineapple, apple, watermelon = 0; // num of each type of fruits
    public Text[] counts = new Text[7];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Fruits.Length; i++)
        {
            Fruits[i].GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        EndPanel.SetActive(false);

        StartCoroutine(FinalNumOfFruits());

    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0));


    }
    // increasing  the falling speed of Fruits
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (sum >= 5)
        {
            for (int i = 0; i < Fruits.Length; i++)
            {
                Fruits[i].GetComponent<Rigidbody2D>().gravityScale = 5;
            }

        }
        if (sum >= 10)
        {
            for (int i = 0; i < Fruits.Length; i++)
            {
                Fruits[i].GetComponent<Rigidbody2D>().gravityScale = 10;
            }
        }

        // Counting the number of each type of Fruits that the player got it as well as the overall sum

        if (collision.gameObject.CompareTag("Lemon"))
        { lemon++; Destroy(collision.gameObject); sum++;
            SoundManager.instance.playSound(GetPoint);
        }
        else if (collision.gameObject.CompareTag("Strawberry"))

        { strawberry++; Destroy(collision.gameObject); sum++;
            SoundManager.instance.playSound(GetPoint);
        }
        else if (collision.gameObject.CompareTag("Pineapple"))
        { pineapple++; Destroy(collision.gameObject); sum++;
            SoundManager.instance.playSound(GetPoint);
        }
        else if (collision.gameObject.CompareTag("Cherry"))
        { cherry++; Destroy(collision.gameObject); sum++;
            SoundManager.instance.playSound(GetPoint);
        }
        else if (collision.gameObject.CompareTag("Apple"))
        { apple++; Destroy(collision.gameObject); sum++;
            SoundManager.instance.playSound(GetPoint);
        }
        else if (collision.gameObject.CompareTag("Banana"))
        { banana++; Destroy(collision.gameObject); sum++;
            SoundManager.instance.playSound(GetPoint);
        }
        else if (collision.gameObject.CompareTag("Watermelon"))
        { watermelon++; Destroy(collision.gameObject); sum++;
            SoundManager.instance.playSound(GetPoint);
        }
        //displaying the num of each kind of fruits that the player got it
        counts[0].text = " " + lemon + " ";
        counts[1].text = " " + strawberry + " ";
        counts[2].text = " " + pineapple + " ";
        counts[3].text = " " + cherry + " ";
        counts[4].text = " " + apple + " ";
        counts[5].text = " " + banana + " ";
        counts[6].text = " " + watermelon + " ";
        Txt.text = " " + sum + " ";



    }
    // Determining the Time of the game Then Counting the sum 
    public IEnumerator FinalNumOfFruits()
    {
        yield return new WaitForSeconds(100);

        //s[0] = int.Parse(counts[0].text);// lemon;
        //s[1] = int.Parse(counts[1].text);// strawberry;
        //s[2] = int.Parse(counts[2].text);// pineapple;
        //s[3] = int.Parse(counts[3].text); //cherry;
        //s[4] = int.Parse(counts[4].text); //apple;
        //s[5] = int.Parse(counts[5].text); //banana;
        //s[6] = int.Parse(counts[6].text);// watermelon;
        //                                 // for(int i = 0; i < s.Length; i++)
                                         //{
                                         //     Debug.Log(s[i]);
                                         // }
                                         // Application.Quit();
                                         // UnityEditor.EditorApplication.isPlaying = false;
        EndPanel.SetActive(true);
        if (sum > 26)
        {

            CongGoodLuck.text = " Congratulation";
            winloose.text = " you win! your score is :" + sum;
            SoundManager.instance.playSound(winSound);

        }
        else
        {

            CongGoodLuck.text = "GoodLuck";
            winloose.text = " you loose! your score is : " + sum;
            SoundManager.instance.playSound(loosingSound);

        }



    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void Restart()
    {
        UnityEditor.EditorApplication.isPaused = false;
        EndPanel.SetActive(false);
        UnityEditor.EditorApplication.isPlaying = true;


    }
}
