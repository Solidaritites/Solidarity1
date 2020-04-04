using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChangeReactor : Reactor
{
    public TileReactor Tile;
    public MeshRenderer MeshRenderer;
    public int IdxToActivate;
    public Material Material;

    public TileChangeReactor[] OtherReactors;

    private Material OldMaterial;
    private int OldIdx;
    private bool Reacted;

    private void Start()
    {
        OldMaterial = MeshRenderer.material;
        OldIdx = Tile.AllowedCharacterIdx;
    }

    public override void React()
    {
        Tile.AllowedCharacterIdx = IdxToActivate;
        MeshRenderer.material = Material;

        foreach (TileChangeReactor otherReactor in OtherReactors)
        {
            if (otherReactor.Reacted)
            {
                Tile.AllowedCharacterIdx = OldIdx;
                MeshRenderer.material = OldMaterial;
            }
        }

        Reacted = true;
    }

    public override void Unreact()
    {
        int count = 0;
        foreach (TileChangeReactor otherReactor in OtherReactors)
        {
            if (otherReactor.Reacted)
            {
                Tile.AllowedCharacterIdx = otherReactor.IdxToActivate;
                MeshRenderer.material = otherReactor.Material;
                count += 1;
            }
        }

        if (count != 1)
        {
            Tile.AllowedCharacterIdx = OldIdx;
            MeshRenderer.material = OldMaterial;
        }

        Reacted = false;
    }
}
