using System;

public abstract class AstNode
{
    public int Value { get; protected set; }
    public abstract void Accept(IVisitor visitor);
    public abstract void Print();
    public abstract int Compute(); // Изменено на возвращение значения
}

public class NumberNode : AstNode
{
    public NumberNode(int value)
    {
        Value = value;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitNumberNode(this);
    }

    public override void Print()
    {
        Console.Write(Value);
    }

    public override int Compute()
    {
        return Value;
    }
}

public class AdditionNode : AstNode
{
    public AstNode Left { get; set; }
    public AstNode Right { get; set; }

    public AdditionNode(AstNode left, AstNode right)
    {
        Left = left;
        Right = right;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitAdditionNode(this);
    }

    public override void Print()
    {
        Console.Write("(");
        Left.Print();
        Console.Write(" + ");
        Right.Print();
        Console.Write(")");
    }

    public override int Compute()
    {
        return Left.Compute() + Right.Compute();
    }
}

public class DiffNode : AstNode
{
    public AstNode Left { get; set; }
    public AstNode Right { get; set; }

    public DiffNode(AstNode left, AstNode right)
    {
        Left = left;
        Right = right;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitDiffNode(this);
    }

    public override void Print()
    {
        Console.Write("(");
        Left.Print();
        Console.Write(" - ");
        Right.Print();
        Console.Write(")");
    }

    public override int Compute()
    {
        return Left.Compute() - Right.Compute();
    }
}

public class DivisionNode : AstNode
{
    public AstNode Left { get; set; }
    public AstNode Right { get; set; }

    public DivisionNode(AstNode left, AstNode right)
    {
        Left = left;
        Right = right;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitDivisionNode(this);
    }

    public override void Print()
    {
        Console.Write("(");
        Left.Print();
        Console.Write(" / ");
        Right.Print();
        Console.Write(")");
    }

    public override int Compute()
    {
        return Left.Compute() / Right.Compute();
    }
}

public class MultNode : AstNode
{
    public AstNode Left { get; set; }
    public AstNode Right { get; set; }

    public MultNode(AstNode left, AstNode right)
    {
        Left = left;
        Right = right;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitMultNode(this);
    }

    public override void Print()
    {
        Console.Write("(");
        Left.Print();
        Console.Write(" * ");
        Right.Print();
        Console.Write(")");
    }

    public override int Compute()
    {
        return Left.Compute() * Right.Compute();
    }
}

public interface IVisitor
{
    void VisitNumberNode(NumberNode numberNode);
    void VisitAdditionNode(AdditionNode additionNode);
    void VisitDiffNode(DiffNode diffNode);
    void VisitDivisionNode(DivisionNode divisionNode);
    void VisitMultNode(MultNode multNode);
}

public class PrintVisitor : IVisitor
{
    public void VisitNumberNode(NumberNode numberNode)
    {
        numberNode.Print();
    }

    public void VisitAdditionNode(AdditionNode additionNode)
    {
        additionNode.Print();
    }

    public void VisitDiffNode(DiffNode diffNode)
    {
        diffNode.Print();
    }

    public void VisitDivisionNode(DivisionNode divisionNode)
    {
        divisionNode.Print();
    }

    public void VisitMultNode(MultNode multNode)
    {
        multNode.Print();
    }
}

public class ComputeVisitor : IVisitor
{
    public void VisitNumberNode(NumberNode numberNode)
    {
        Console.WriteLine(numberNode.Compute());
    }

    public void VisitAdditionNode(AdditionNode additionNode)
    {
        Console.WriteLine(additionNode.Compute());
    }

    public void VisitDiffNode(DiffNode diffNode)
    {
        Console.WriteLine(diffNode.Compute());
    }

    public void VisitDivisionNode(DivisionNode divisionNode)
    {
        Console.WriteLine(divisionNode.Compute());
    }

    public void VisitMultNode(MultNode multNode)
    {
        Console.WriteLine(multNode.Compute());
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        NumberNode first = new NumberNode(1);
        NumberNode sec = new NumberNode(2);
        NumberNode three = new NumberNode(3);

        // Создаем узел сложения для первых двух чисел
        AstNode addNode = new AdditionNode(first, sec);
        // Создаем узел вычитания
        AstNode diffNode = new DiffNode(addNode, three);
        // Создаем узел деления
        AstNode divNode = new DivisionNode(addNode, three);
        // Создаем узел умножения
        AstNode multNode = new MultNode(first, sec);

        AstNode addNode_Sec = new AdditionNode(addNode, multNode);

        var printer = new PrintVisitor();
        Console.WriteLine("AST:");
        addNode.Accept(printer);
        Console.WriteLine();
        diffNode.Accept(printer);
        Console.WriteLine();
        divNode.Accept(printer);
        Console.WriteLine();
        multNode.Accept(printer);
        Console.WriteLine();
        addNode_Sec.Accept(printer);
        Console.WriteLine();

        var computeVisitor = new ComputeVisitor();
        Console.WriteLine("Результаты вычислений:");
        addNode.Accept(computeVisitor);
        diffNode.Accept(computeVisitor);
        divNode.Accept(computeVisitor);
        multNode.Accept(computeVisitor);
    }
}
