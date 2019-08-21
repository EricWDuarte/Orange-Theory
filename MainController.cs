using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{

    public GameObject textStart;
    public GameObject endText;

    public Transform player;
    public Material playerMat;
    public Material wallMat;

    public AudioClip startMusic;
    public AudioClip mainMusic;

    private AudioSource source;


    public Color playerColor;
    public Color wallColor;
    public Color backColor;

    bool monoToColor = false;
    bool colorToInverted = false;
    bool colorCrazy = false;

    float playerH, playerS, playerV;
    float wallH, wallS, wallV;
    float backH, backS, backV;


    float timer = 0f;



    private bool mainMusicStarted = false;

    // Use this for initialization
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        StartCoroutine(MusicStart());

        playerMat.color = Color.HSVToRGB(playerH, 0, playerV);
        wallMat.color = Color.HSVToRGB(wallH, 0, wallV);
        Camera.main.backgroundColor = Color.HSVToRGB(backH, 0, backV);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (player.position.y < -5f)
        {
            textStart.SetActive(false);
            mainMusicStarted = true;
        }

        if (player.position.y < -50f && monoToColor == false)
        {
            monoToColor = true;
            timer = 1.5f;

            Color.RGBToHSV(playerColor, out playerH, out playerS, out playerV);
            Color.RGBToHSV(wallColor, out wallH, out wallS, out wallV);
            Color.RGBToHSV(backColor, out backH, out backS, out backV);

        }

        if (player.position.y < -264f)
        {
            ConeRotation.rot = 5f;
        }


        if (player.position.y < -528f && colorToInverted == false)
        {
            colorToInverted = true;
            timer = 0;

            Color.RGBToHSV(playerColor, out playerH, out playerS, out playerV);
            Color.RGBToHSV(wallColor, out wallH, out wallS, out wallV);
            Color.RGBToHSV(backColor, out backH, out backS, out backV);

        }

        if (player.position.y < -700f && monoToColor == false)
        {
            colorCrazy = true;
            timer = 0;

            Color.RGBToHSV(playerColor, out playerH, out playerS, out playerV);
            Color.RGBToHSV(wallColor, out wallH, out wallS, out wallV);
            Color.RGBToHSV(backColor, out backH, out backS, out backV);

        }

        if (player.position.y < -1054f)
        {
            endText.SetActive(true);

        }




        if (colorCrazy == true)
        {
            playerMat.color = Color.HSVToRGB(Mathf.Repeat(playerH + timer * 0.5f / 3f, 1f), playerS, playerV);
            wallMat.color = Color.HSVToRGB(Mathf.Repeat(wallH + timer * 0.5f / 3f, 1f), wallS, wallV);
            Camera.main.backgroundColor = Color.HSVToRGB(Mathf.Repeat(backH + timer * 0.5f / 3f, 1f), backS, backV);

        }
        else if (colorToInverted == true && timer < 3f)
        {
            playerMat.color = Color.HSVToRGB(Mathf.Repeat(playerH + timer * 0.5f / 3f, 1f), playerS, playerV);
            wallMat.color = Color.HSVToRGB(Mathf.Repeat(wallH + timer * 0.5f / 3f, 1f), wallS, wallV);
            Camera.main.backgroundColor = Color.HSVToRGB(Mathf.Repeat(backH + timer * 0.5f / 3f, 1f), backS, backV);
        }
        else if (monoToColor == true && timer < 3f)
        {
            playerMat.color = Color.HSVToRGB(playerH, playerS * timer / 3f, playerV);
            wallMat.color = Color.HSVToRGB(wallH, wallS * timer / 3f, wallV);
            Camera.main.backgroundColor = Color.HSVToRGB(backH, backS * timer / 3f, backV);
        }
    }

    IEnumerator MusicStart()
    {

        yield return new WaitForSeconds(startMusic.length);
        if (mainMusicStarted == true)
        {
            source.clip = mainMusic;
            source.Play();
        }
        else
        {
            StartCoroutine(MusicStart());
        }

    }
}
