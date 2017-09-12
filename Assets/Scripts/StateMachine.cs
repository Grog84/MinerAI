using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private minerAI m_miner;
    private State m_CurrentState;
    private State m_PreviousState;
    private State m_GlobalState;

    private State m_Drink, m_Rest, m_DepositGold, m_Dig;

    public StateMachine(minerAI miner)
    {
        m_miner = miner;

        m_Rest = new Rest();
        m_Dig = new Digging();
        m_Drink = new Drink();
        m_DepositGold = new DepositGold();

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

    void ChangeState()
    {
        m_PreviousState = m_CurrentState;
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_CurrentState != null)
            m_CurrentState.Execute(m_miner);
	}
}
