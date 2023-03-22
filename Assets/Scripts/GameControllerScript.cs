using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public const int columns = 4;
    public const int rows = 4;

    public const float spaceX = 2.68f;
    public const float spaceY = -2.51f;

    [SerializeField] private MainImScript startObject;
    [SerializeField] private Sprite[] images;

    private int[] Randomiser(int[] locations) 
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7};
        locations = Randomiser(locations);
        
        Vector3 startPosition = startObject.transform.position;

        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                MainImScript gameImage;
                if(i==0 && j==0)
                {
                    gameImage = startObject;
                }
                else 
                {
                    gameImage = Instantiate(startObject) as MainImScript;
                }
                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (spaceX * i) + startPosition.x; 
                float positionY = (spaceY * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private MainImScript firstOpen;
    private MainImScript secondOpen;

    private int score = 0;
    private int tries = 0;

    [SerializeField] private TextMesh scoreText;
    [SerializeField] private TextMesh triesText;

    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void imageOpened(MainImScript startObject)
    {
        if (firstOpen == null)
        {
            firstOpen = startObject;
        }
        else 
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if(firstOpen.spriteId == secondOpen.spriteId)
        {
            score++; 
            scoreText.text = "Score: " + score;
            if(score == 8){
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene("WinScreen");
            }
        }
        else 
        {
            yield return new WaitForSeconds(0.5f);
            firstOpen.Close();
            secondOpen.Close();
        }

        tries++;
        triesText.text= "Tries: " + tries;

        firstOpen = null;
        secondOpen = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
