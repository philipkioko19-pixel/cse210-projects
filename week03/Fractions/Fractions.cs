using System;

public class Fraction
{
    // Private attributes for the top and bottom numbers
    private int _top;
    private int _bottom;

    // 1. Constructor with no parameters (initializes to 1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. Constructor with one parameter for the top (initializes bottom to 1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 3. Constructor with two parameters for top and bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Method to return the fraction in the form "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return the decimal value as a double
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}