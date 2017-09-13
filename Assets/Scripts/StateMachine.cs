using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {

    private minerAI m_miner;
    private State m_PreviousState;
    private State m_Drink, m_Rest, m_DepositGold, m_Dig;

    public State m_CurrentState;
    public State m_GlobalState;

    public StateMachine(minerAI miner)
    {
        m_miner = miner;

        m_Rest = new Rest();
        m_Dig = new Digging();
        m_Drink = new Drink();
        m_DepositGold = new DepositGold();
        m_GlobalState = new GlobalState();

        SetCurrentState();
    }

    void SetCurrentState()
    {
        m_CurrentState = m_Rest;
    }

    void SetCurrentState(State state)
    {
        m_CurrentState = state;
    }

    void ChangeState(State state)
    {
        m_CurrentState.Exit(m_miner);
        m_PreviousState = m_CurrentState;
        state.Enter(m_miner);
        SetCurrentState(state);
    }

    public void GlobalExecute()
    {
        ChangeState(m_Drink);
        m_Drink.Execute(m_miner);
        ChangeState(m_PreviousState);
    }

    public void CheckState()
    {
        if (m_CurrentState == m_Rest && m_miner.GetFatigue() <= 0 && m_miner.GetSavings() < 8)
        {
            ChangeState(m_Dig);
        }
        else if (m_CurrentState == m_Rest && m_miner.GetFatigue() <= 0 && m_miner.GetSavings() >= 8)
        {
            m_Rest.Exit(m_miner);
            Application.Quit();
        }
        else if (m_CurrentState == m_Dig && m_miner.GetSpaceInPocket() == 0)
        {
            ChangeState(m_DepositGold);
        }
        else if (m_CurrentState == m_DepositGold && ((m_miner.GetSavings() < 8 && m_miner.GetFatigue() > 5) || (m_miner.GetSavings() >= 8)))
        {
            ChangeState(m_Rest);
        }
        else if (m_CurrentState == m_DepositGold && m_miner.GetSavings() < 8 && m_miner.GetFatigue() < 5)
        {
            ChangeState(m_Dig);
        }
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //m_GlobalState.Execute(m_miner);
        //if (m_CurrentState != null)
        //    m_CurrentState.Execute(m_miner);
        //CheckState();
    }
}
