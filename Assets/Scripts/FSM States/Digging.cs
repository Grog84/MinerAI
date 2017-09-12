using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Digging : ScriptableObject, IState {
public class Digging : State {
    
    enum Locations { goldmine, bank, saloon, home };

    override public void Enter(minerAI miner)
    {
        if (miner.GetLocation() != (int)Locations.goldmine)
            miner.ChangeLocation((int)Locations.goldmine);
        Debug.Log("Let's start digging!");
        //Execute(miner);
    }

    override public void Execute(minerAI miner)
    {
        Debug.Log("Oh! What a nice nugget I found!");
        miner.FillPockets();

        miner.IncreaseFatigue();
        miner.IncreaseThirst();

        //if (miner.GetSpaceInPocket() == 0)
        //    Exit(miner);
        //else
        //    Execute(miner);
    }

    override public void Exit(minerAI miner)
    {
        Debug.Log("Got my pocket filled with good sweet gold! Time to go!");
    }
}
