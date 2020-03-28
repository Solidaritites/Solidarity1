using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialReactor : Reactor
{
    public Renderer Renderer;
    public Material ReactionMaterial;

    private Material DefaultMaterial;

    private void Start()
    {
        DefaultMaterial = Renderer.material;
    }

    public override void React()
    {
        Renderer.material = ReactionMaterial;
    }

    public override void Unreact()
    {
        Renderer.material = DefaultMaterial;
    }
}
