using System.Collections;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{
    public GameManager gameManager;
    public Transform[] enviro;
    public Transform heightGauge;
    public Animator camAnimator;

    public string[] line1Options;
    public string[] line2Options;

    private string[] startText1;
    private string[] startText2;

    private float UpDown;
    private float height;
    bool endflag = false;
    bool startflag = false;

    float startTime = 0;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;

        startText1 = new string[enviro.Length];
        startText2 = new string[enviro.Length];

        for (int n = 0; n < enviro.Length; n++)
        {
            startText1[n] = enviro[n].GetChild(0).GetComponent<TextMesh>().text;
            startText2[n] = enviro[n].GetChild(1).GetComponent<TextMesh>().text;
        }

        Reset();
    }

    public void Reset()
    {
        if (!endflag && startText1 != null)
        {
            for (int n = 0; n < enviro.Length; n++)
            {
                enviro[n].GetChild(0).GetComponent<TextMesh>().text = startText1[n];
                enviro[n].GetChild(1).GetComponent<TextMesh>().text = startText2[n];
            }

            foreach (Transform t in enviro)
            {
                t.position = t.position + 24 * Vector3.right;
                RandomizeColor(t);
            }

            height = 0;
            UpdateHeightGauge();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startflag)
        {
            UpDown *= 0.92f;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                UpDown += 4;

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                UpDown -= 4;

            transform.rotation = Quaternion.Euler(0, 0, UpDown);

            Vector3 speed = transform.rotation * Vector3.left;
            height -= speed.y * 0.001f;

            if (height < 0)
                height = 0;

            UpdateHeightGauge();

            foreach (Transform t in enviro)
            {
                t.position = t.position + Time.deltaTime * speed * 12;

                if (t.localPosition.x < -17 && height < 1 && !endflag)
                {
                    t.position = t.position + 34 * Vector3.right + 4 * Vector3.up * (Random.value - 0.5f);
                    t.rotation = Quaternion.Euler(-43.8f, 320 * Random.value, 25.37f);

                    RandomizeColor(t);
                    RandomizeText(t);
                }

                if (t.localPosition.y < -6)
                {
                    t.position = t.position + 24f * Vector3.up;
                }

                if (t.position.y > 18)
                {
                    t.position = t.position - 24f * Vector3.up;
                }
            }

            if (height >= 1)
            {
                bool noCloud = true;

                foreach (Transform t in enviro)
                    if (t.localPosition.x >= -17)
                        noCloud = false;

                if (noCloud)
                    theEnd();
            }
        }
        else
        if (Time.time - startTime > 2)
            startflag = true;

        if (Input.GetKey(KeyCode.Escape))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void theEnd()
    {
        endflag = true;
        transform.parent.GetComponent<Animator>().Play("FlightEnd");
        StartCoroutine(AdvanceLevel());
    }

    IEnumerator AdvanceLevel()
    {
        yield return new WaitForSeconds(8);

        gameManager.Ball.gameObject.SetActive(true);
        gameManager.LevelUp();
    }

    private void UpdateHeightGauge()
    {
        Vector3 pos = heightGauge.localPosition;
        pos.y = height - 0.5f;

        heightGauge.localPosition = pos;
    }

    private void RandomizeColor(Transform t)
    {
        t.GetComponent<MeshRenderer>().material.color = new Color32((byte)Random.Range(0, 64), 0, (byte)Random.Range(64, 96), 0);
    }

    private void RandomizeText(Transform t)
    {
        string text = line1Options[Random.Range(0, line1Options.Length)].ToUpper() + System.Environment.NewLine + line2Options[Random.Range(0, line2Options.Length)].ToUpper();
        t.GetChild(0).GetComponent<TextMesh>().text = text;
        t.GetChild(1).GetComponent<TextMesh>().text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!endflag)
        {
            camAnimator.Play("CamRedFlash");
            GameManager.Instance.RestartLevel();
        }
    }
}
