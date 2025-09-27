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
        Assert.Equal("42", result);
    }

    [Fact]
    public void Visit_AdditionNode_PrintsExpression()
    {
        // Arrange
        var leftNode = new NumberNode(1);
        var rightNode = new NumberNode(2);
        var additionNode = new AdditionNode(leftNode, rightNode);
        var printer = new PrintVisitor();

        // Redirect console output to a StringWriter
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        additionNode.Accept(printer);

        // Assert
        var result = sw.ToString().Trim();
        Assert.Equal("(1 + 2)", result);
    }

    [Fact]
    public void Visit_ComplexAdditionNode_PrintsExpression()
    {
        // Arrange
        var leftNode = new AdditionNode(new NumberNode(1), new NumberNode(2));
        var rightNode = new NumberNode(3);
        var complexAddition = new AdditionNode(leftNode, rightNode);
        var printer = new PrintVisitor();

        // Redirect console output to a StringWriter
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        complexAddition.Accept(printer);

        // Assert
        var result = sw.ToString().Trim();
        Assert.Equal("((1 + 2) + 3)", result);
    }

    [Fact]
    public void Visit_DiffNode_PrintsExpression()
    {
        // Arrange
        var leftNode = new NumberNode(5);
        var rightNode = new NumberNode(3);
        var diffNode = new DiffNode(leftNode, rightNode);
        var printer = new PrintVisitor();

        // Redirect console output to a StringWriter
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        diffNode.Accept(printer);

        // Assert
        var result = sw.ToString().Trim();
        Assert.Equal("(5 - 3)", result);
    }

    [Fact]
    public void Visit_DivisionNode_PrintsExpression()
    {
        // Arrange
        var leftNode = new NumberNode(6);
        var rightNode = new NumberNode(2);
        var divisionNode = new DivisionNode(leftNode, rightNode);
        var printer = new PrintVisitor();

        // Redirect console output to a StringWriter
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        divisionNode.Accept(printer);

        // Assert
        var result = sw.ToString().Trim();
        Assert.Equal("(6 / 2)", result);
    }

    [Fact]
    public void Visit_MultNode_PrintsExpression()
    {
        // Arrange
        var leftNode = new NumberNode(4);
        var rightNode = new NumberNode(5);
        var multNode = new MultNode(leftNode, rightNode);
        var printer = new PrintVisitor();

        // Redirect console output to a StringWriter
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        multNode.Accept(printer);

        // Assert
        var result = sw.ToString().Trim();
        Assert.Equal("(4 * 5)", result);
    }
}
