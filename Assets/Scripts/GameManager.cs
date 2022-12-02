using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const int columns = 4;
    public const int rows = 2;
    public const float Xspace = 4f;
    public const float Yspace = -5f;
    private MainImage firstOpen;
    private MainImage secondOpen;
    public ParticleSystem matchParticle;
    public AudioClip matchSound;
    private AudioSource gameAudio;
  
    public static int score = 0;
    private int attempts = 0;
    [SerializeField] private TextMesh scoreText;
    [SerializeField]private TextMesh attempsText;
    [SerializeField] private MainImage startObject;
    [SerializeField] private Sprite[] images;
     public bool canOpen
    {
        get { return secondOpen == null; }
    }

    private int[] Randomiser(int[] locations){
        int[] array = locations.Clone() as int[];
        for(int i=0; i < array.Length; i++){
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }

        return array;
    }

    private void Start(){
        gameAudio = GetComponent<AudioSource>();
        int[] locations = {0,0,1,1,2,2,3,3};
        locations = Randomiser(locations);
        Vector3 startPosition = startObject.transform.position;

        for(int i = 0; i < columns; i++){
            for(int j = 0; j < rows; j++){
                MainImage gameImage;
                if(i == 0 && j == 0){
                    
                    gameImage = startObject;
                }else{
                    gameImage = Instantiate(startObject) as MainImage;
                }
                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }

        }
    }
    public void ImageOpened(MainImage startObject){
        if (firstOpen == null){
            firstOpen = startObject;
        }else{
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed(){
        if(firstOpen.spriteId == secondOpen.spriteId){
            score++;
            scoreText.text = "Score: "+ score;
            matchParticle.Play();
            gameAudio.PlayOneShot(matchSound);
            

        }else{
            yield return new WaitForSeconds(0.5f);
            firstOpen.Close();
            secondOpen.Close();
        }
        attempts++;
        attempsText.text = "Attempts: " + attempts;

        firstOpen = null;
        secondOpen = null;

    }

    public void Reset(){
        SceneManager.LoadScene("MainScene");
    }


}
