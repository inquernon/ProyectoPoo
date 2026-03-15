using UnityEngine;

public interface IDaniable
{
    int Vida{ get; set; }
    void RecibirDanio(int cantidad);
}
