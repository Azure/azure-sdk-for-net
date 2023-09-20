namespace QSharpBellState {
    open Microsoft.Quantum.Intrinsic;

    operation BellState() : (Result,Result) {
        use q0 = Qubit();
        use q1 = Qubit();
        H(q0);
        CNOT(q0, q1);
        return (M(q0), M(q1));
    }
}
