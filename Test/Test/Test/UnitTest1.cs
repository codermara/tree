using System;
using System.IO;
using Xunit;

public class PrintVisitorTests
{
    [Fact]
    public void Visit_NumberNode_PrintsValue()
    {
        // Arrange
        var numberNode = new NumberNode(42);
        var printer = new PrintVisitor();

        // Redirect console output to a StringWriter
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        numberNode.Accept(printer);

        // Assert
        var result = sw.ToString().Trim();
        Assert.Equal("43", result);
    }

    [Fact]
    public void Visit_BinaryExpressionNode_PrintsExpression()
    {
        // Arrange
        var leftNode = new NumberNode(1);
        var rightNode = new NumberNode(2);
        var binaryExpression = new BinaryExpressionNode(leftNode, "+", rightNode);
        var printer = new PrintVisitor();

        // Redirect console output to a StringWriter
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        binaryExpression.Accept(printer);

        // Assert
        var result = sw.ToString().Trim();
        Assert.Equal("(1 + 2)", result);
    }

    [Fact]
    public void Visit_ComplexBinaryExpressionNode_PrintsExpression()
    {
        // Arrange
        var leftNode = new BinaryExpressionNode(new NumberNode(1), "+", new NumberNode(2));
        var rightNode = new NumberNode(3);
        var complexExpression = new BinaryExpressionNode(leftNode, "*", rightNode);
        var printer = new PrintVisitor();

        // Redirect console output to a StringWriter
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        complexExpression.Accept(printer);

        // Assert
        var result = sw.ToString().Trim();
        Assert.Equal("((1 + 2) * 3)", result);
    }
}