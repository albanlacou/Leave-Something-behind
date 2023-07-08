using System;
public class Agavoiture : Artifact
{
	private string name;

	public Agavoiture()
	{
		this.name = "agavoiture";
	}

    public void doEffect(Player p)
    {
		p.attackValue += 2;
    }

    public void undoEffect(Player p)
    {
        p.attackValue -= 2;
    }
}

