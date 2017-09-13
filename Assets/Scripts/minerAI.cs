using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minerAI : MonoBehaviour {

    enum Locations { goldmine, bank, saloon, home };

    private int m_GoldCarried = 0, m_GoldInBank = 0, m_Thirst = 0, m_Fatigue = 0;
    private int m_Location = 3;
    private int m_SpaceInPockets = 2;

    private StateMachine m_StateMachine;

    public minerAI()
    {
        m_StateMachine = new StateMachine(this);
    }

    // Get Variables
    public int GetLocation()
    {
        return m_Location;
    }

    public int GetSavings()
    {
        return m_GoldInBank;
    }

    public int GetFatigue()
    {
        return m_Fatigue;
    }

    public int GetThirst()
    {
        return m_Thirst;
    }

    public int GetSpaceInPocket()
    {
        return m_SpaceInPockets;
    }

    public StateMachine GetStateMachine()
    {
        return m_StateMachine;
    }

    // States Actions
    public void FillPockets()
    {
        m_SpaceInPockets -= 1;
        m_GoldCarried += 1;
    }

    public void EmptyPockets()
    {
        m_SpaceInPockets = 2;
        m_GoldCarried = 0;
    }

    public void DepositGold()
    {
        m_GoldInBank += m_GoldCarried;
        m_SpaceInPockets = 2;
        m_GoldCarried = 0;
    }

    public void ChangeLocation(int location)
    {
        m_Location = location;
    }

    public void IncreaseFatigue()
    {
        m_Fatigue += 1;
    }

    public void IncreaseThirst()
    {
        m_Thirst += 1;
    }

    public void PayDrink()
    {
        m_GoldCarried -= 1;
        m_SpaceInPockets += 1;
    }

    public void Drink()
    {
        m_Thirst = 0;
        PayDrink();
    }

    public void Rest()
    {
        m_Fatigue -= 1;

    }

    // Use this for initialization
    void Start () {
        m_StateMachine = new StateMachine(this);
    }
	
	// Update is called once per frame
	void Update () {
        m_StateMachine.m_GlobalState.Execute(this);
        if (m_StateMachine.m_CurrentState != null)
            m_StateMachine.m_CurrentState.Execute(this);
        m_StateMachine.CheckState();
    }
}
