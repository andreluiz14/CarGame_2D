using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontosEntregas : MonoBehaviour
{
    [SerializeField] List<GameObject> pontoEntrega = new List<GameObject>();
    // Start is called before the first frame update
    private void Start()
    {

    }
    public void EntrouNoTrigger2D(Collider2D veiculo, IdPonto id)
    {
        print(veiculo + "  " + id);
    }
}
