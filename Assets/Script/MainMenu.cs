using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        // เช็คว่าผู้เล่นกดปุ่ม Spacebar หรือไม่
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // โหลดหน้า Screen Credit
            SceneManager.LoadScene("Credit");
        }
    }
    
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Credit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
}
