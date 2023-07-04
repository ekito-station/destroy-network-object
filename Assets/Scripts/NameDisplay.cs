using Photon.Pun;
using TMPro;

public class NameDisplay : MonoBehaviourPunCallbacks
{
    void Start()
    {
        var nameLabel = GetComponent<TextMeshProUGUI>();
        nameLabel.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }
}