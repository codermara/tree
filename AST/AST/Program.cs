// Базовый класс для всех узлов AST
public abstract class AstNode
{
    public abstract void Accept(IVisitor visitor);
}

// Класс для представления числового литерала
public class NumberNode : AstNode
{
    public int Value { get; }

    public NumberNode(int value)
    {
        Value = value;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Класс для представления бинарного выражения
public class BinaryExpressionNode : AstNode
{
    public AstNode Left { get; }
    public string Operator { get; }
    public AstNode Right { get; }

    public BinaryExpressionNode(AstNode left, string operatorSymbol, AstNode right)
    {
        Left = left;
        Operator = operatorSymbol;
        Right = right;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Интерфейс для посетителя
public interface IVisitor
{
    void Visit(NumberNode numberNode);
    void Visit(BinaryExpressionNode binaryExpressionNode);
}

// Пример реализации посетителя для вывода AST
public class PrintVisitor : IVisitor
{
    public void Visit(NumberNode numberNode)
    {
        Console.Write(numberNode.Value);
    }

    public void Visit(BinaryExpressionNode binaryExpressionNode)
    {
        Console.Write("(");
        binaryExpressionNode.Left.Accept(this);
        Console.Write($" {binaryExpressionNode.Operator} ");
        binaryExpressionNode.Right.Accept(this);
        Console.Write(")");
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        //
        // Создание AST для выражения (1 + 2) * 3
        var expression = new BinaryExpressionNode(
            new BinaryExpressionNode(new NumberNode(1), "+", new NumberNode(2)),
            "*",
            new NumberNode(3)
        );

        // Печать AST
        var printer = new PrintVisitor();
        expression.Accept(printer); // Вывод: ((1 + 2) * 3)
/*
        // Создание узлов
        var leftNode = new NumberNode(1);
        var rightNode = new NumberNode(2);
        var binaryExpression = new BinaryExpressionNode(leftNode, "+", rightNode);

        // Создание посетителя
        var printer = new PrintVisitor();

        // Вызов метода Accept
        binaryExpression.Accept(printer);
*/
    }
}
