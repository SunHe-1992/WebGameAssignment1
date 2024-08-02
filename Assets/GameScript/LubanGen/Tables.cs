
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;

namespace cfg
{
public partial class Tables
{
    public SLG.TbConst TbConst {get; }
    public SLG.TbLanguage TbLanguage {get; }
    public SLG.Character Character {get; }
    public SLG.Item Item {get; }
    public SLG.Class Class {get; }
    public SLG.TileEffect TileEffect {get; }
    public SLG.Skill Skill {get; }
    public SLG.TbPawn TbPawn {get; }
    public SLG.TbAttr TbAttr {get; }
    public SLG.TbDialogue TbDialogue {get; }
    public SLG.TbQuest TbQuest {get; }

    public Tables(System.Func<string, JSONNode> loader)
    {
        TbConst = new SLG.TbConst(loader("slg_tbconst"));
        TbLanguage = new SLG.TbLanguage(loader("slg_tblanguage"));
        Character = new SLG.Character(loader("slg_character"));
        Item = new SLG.Item(loader("slg_item"));
        Class = new SLG.Class(loader("slg_class"));
        TileEffect = new SLG.TileEffect(loader("slg_tileeffect"));
        Skill = new SLG.Skill(loader("slg_skill"));
        TbPawn = new SLG.TbPawn(loader("slg_tbpawn"));
        TbAttr = new SLG.TbAttr(loader("slg_tbattr"));
        TbDialogue = new SLG.TbDialogue(loader("slg_tbdialogue"));
        TbQuest = new SLG.TbQuest(loader("slg_tbquest"));
        ResolveRef();
    }
    
    private void ResolveRef()
    {
        TbConst.ResolveRef(this);
        TbLanguage.ResolveRef(this);
        Character.ResolveRef(this);
        Item.ResolveRef(this);
        Class.ResolveRef(this);
        TileEffect.ResolveRef(this);
        Skill.ResolveRef(this);
        TbPawn.ResolveRef(this);
        TbAttr.ResolveRef(this);
        TbDialogue.ResolveRef(this);
        TbQuest.ResolveRef(this);
    }
}

}