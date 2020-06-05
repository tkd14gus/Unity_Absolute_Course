using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManag : MonoBehaviour
{
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("Play", LoadSceneMode.Additive);
    }
}
