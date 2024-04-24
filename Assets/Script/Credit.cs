using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    void Update()
    {
        // เช็คว่าผู้เล่นกดปุ่ม Spacebar หรือไม่
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // โหลดหน้า Screen 0
            SceneManager.LoadScene("MainMenu");
        }
    }
}