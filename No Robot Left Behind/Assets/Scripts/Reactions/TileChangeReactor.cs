using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChangeReactor : Reactor
{
    public TileReactor Tile;
    public MeshRenderer MeshRenderer;
    public int IdxToActivate;
    public Material Material;

    public override void React()
    {
        Tile.AllowedCharacterIdx = IdxToActivate;
        MeshRenderer.material = Material;
    }

    public override void Unreact()
    {

    }
}
