using UnityEngine;
using TMPro;

public class TypingGame : MonoBehaviour
{
    public static TypingGame Instance;
    
    [SerializeField] private GameObject minigameUI;
    [SerializeField] private TMP_Text letterText;
    
    private char currentLetter;
    private bool isActive = false;
    
    void Awake()
    {
        Instance = this;
    }
    
    public void Activate()
    {
        isActive = true;
        minigameUI.SetActive(true);
        GenerateNewLetter();
        Debug.Log("Minigame aktiviert");
    }
    
    public void Deactivate()
    {
        isActive = false;
        minigameUI.SetActive(false);
        Debug.Log("Minigame deaktiviert");
    }
    
    void GenerateNewLetter()
    {
        currentLetter = (char)Random.Range('A', 'Z' + 1);
        letterText.text = currentLetter.ToString();
    }
    
    void Update()
    {
        if (!isActive) return;
        
        foreach (char c in Input.inputString)
        {
            if (char.ToUpper(c) == currentLetter)
            {
                Debug.Log("Richtig!");
                Debug.Log("TODO: Hier macht PERSON 3 weiter - ScoreManager.Instance.AddScore(10) aufrufen");
                GenerateNewLetter();
            }
        }
    }
}