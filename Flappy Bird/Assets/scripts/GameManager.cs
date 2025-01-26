using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

    private int prevpoint = -1;
    private Sprite tens;
    private Sprite ones;


    public static int points = 0;
    public static List<GameObject> poles = new List<GameObject>();

    [SerializeField] private List<Texture2D> numbers = new List<Texture2D>();
    [SerializeField] private GameObject tensDisplay;
    [SerializeField] private GameObject onesDisplay;
    [SerializeField] private GameObject TryAgainMenu;
    [SerializeField] private TextMeshProUGUI scoreText;

    private SpriteRenderer tensRenderer;
    private SpriteRenderer onesRenderer;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        points = 0;
        prevpoint = -1;

        tensRenderer = tensDisplay.GetComponent<SpriteRenderer>();
        onesRenderer = onesDisplay.GetComponent<SpriteRenderer>();

        TryAgainMenu.SetActive(false);

    }

    private void Update()
    {
        if (prevpoint != points)
        {
            int tensDigit = (int)points / 10;
            int onesDigit = (int)points % 10;
            tens = Sprite.Create(numbers[tensDigit], new Rect(0, 0, numbers[tensDigit].width, numbers[tensDigit].height), new Vector3(0.5f, 0f, 1f));
            ones = Sprite.Create(numbers[onesDigit], new Rect(0, 0, numbers[onesDigit].width, numbers[onesDigit].height), new Vector3(-0.5f, 0f, 1f));

            tensRenderer.sprite = tens;
            onesRenderer.sprite = ones;


            prevpoint = points;
        }
    }


    public void TryAgain()
    {
        TryAgainMenu.SetActive(true);
        scoreText.text = points.ToString();

    }

    public void ReTry()
    {
        SceneManager.LoadScene("GAME");
        Time.timeScale = 1.0f;
    }
}
