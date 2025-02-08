using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> distances;

    private string _leaderboardPublicKey = "6f5b6e7c47a1adfba8c5e02d38ef33cd06d0964afa9eb04b925a2b2d74cac7a4";

    private void Start()
    {
        GetLeaderboard();
    }

    private void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(_leaderboardPublicKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;

            for (int i = 0; i < loopLength; ++i)
            {
                names[i].text = msg[i].Username;
                distances[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(_leaderboardPublicKey, username, score, ((msg) =>
        {
            GetLeaderboard();
        }));
    }
}
