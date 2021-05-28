using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Postbdd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PostData());
    }

    IEnumerator PostData()
    {
        int score = FindObjectOfType<GameSystem>().scorePlayer;
        score++;
        WWWForm form = new WWWForm();
        //form.AddField("pseudo", "player2");
        form.AddField("pseudo", FindObjectOfType<GameSystem>().pseudoPlayer);
        form.AddField("score", score);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/logiciel_b2_unity/postscore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Données envoyées à la Base de Données");
            }
        }
    }
}
