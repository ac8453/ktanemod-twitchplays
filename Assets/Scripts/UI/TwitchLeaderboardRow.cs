﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TwitchLeaderboardRow : MonoBehaviour
{
    [Header("Text Elements")]
    public Text positionText = null;
    public Text userNameText = null;
    public Text solvesText = null;
    public Text strikesText = null;
    public Text percentText = null;

    [Header("Values")]
    public int position = 0;
    public float delay = 0.0f;
    public Leaderboard.LeaderboardEntry leaderboardEntry = null;

    private CanvasGroup _canvasGroup = null;
    private Animator _animator = null;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();

        _canvasGroup.alpha = 0.0f;
    }

    private IEnumerator Start()
    {
        positionText.text = position.ToString();

        if (leaderboardEntry != null)
        {
            userNameText.text = leaderboardEntry.UserName;
            userNameText.color = leaderboardEntry.UserColor;
            solvesText.text = leaderboardEntry.SolveCount.ToString();
            strikesText.text = leaderboardEntry.StrikeCount.ToString();

            float percent = leaderboardEntry.Percent;
            if (float.IsNaN(percent))
            {
                percentText.text = "--";
            }
            else
            {
                percentText.text = string.Format("{0}%", Mathf.RoundToInt(percent));
            }
        }

        yield return new WaitForSeconds(delay);
        _animator.enabled = true;
    }
}
