using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUnit : MonoBehaviour
{
    public TMP_Text UIText;
    public TextAsset TxtFile;
    public string[] FullDialogue;
    public float CharPerSec;
    private List<char> _curDialogueFull;
    private string _curDialogue;
    private int _dialIndex;
    private int _charIndex;
    private float _charIndexTimer;

    void Start()
    {
        _dialIndex = 0;
        _charIndex = 0;
        if (TxtFile != null) FullDialogue = TxtFile.text.Split('\n');
        SetDialogue();
    }

    void Update()
    {
        UIText.text = _curDialogue;
        UpdateString();
    }

    private void SetDialogue()
    {
        _curDialogueFull = new List<char>();
        for (int i = 0; i < FullDialogue[_dialIndex].Length; i++)
        {
              _curDialogueFull.Add(FullDialogue[_dialIndex][i]);
        }
    }
    private void UpdateString()
    {
        _curDialogue = "";
        for (int i = 0; i < _charIndex; i++)
        {
            _curDialogue += _curDialogueFull[i];
        }

        //to add to the char index with custom cps:
        if (_charIndex >= _curDialogueFull.Count) return;
        _charIndexTimer += Time.deltaTime * CharPerSec;
        if (_charIndexTimer <= 1) return;
        _charIndex += (int)_charIndexTimer;
        _charIndexTimer -= (int)_charIndexTimer;
    }

    public void NextButton()
    {
        if (_charIndex < _curDialogueFull.Count)
        {
            _charIndex = _curDialogueFull.Count;
            return;
        }

        _charIndex = 0;
        _dialIndex++;
        if (_dialIndex > FullDialogue.Length)
        {
            Destroy(gameObject);
            return;
        }
        SetDialogue();
    }


}
