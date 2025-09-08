namespace TimeProject.Core;

public class Time
{
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;



    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecond = 0;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = 0;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }



    public int Hour
    {
        get => _hour;
        set
        {
            _hour = ValidHour(value);
        }
    }
    public int Millisecond
    {
        get => _millisecond;
        set
        {
            _millisecond = ValidMillisecond(value);
        }
    }
    public int Minute
    {
        get => _minute;
        set
        {
            _minute = ValidMinute(value);
        }
    }
    public int Second
    {
        get => _second;
        set
        {
            _second = ValidSecond(value);
        }
    }

    public override string ToString()
    {
        int displayHour;
        string period;

        if (_hour == 0)
        {
            displayHour = 12;
            period = "AM";
        }
        else if (_hour < 12)
        {
            displayHour = _hour;
            period = "AM";
        }
        else if (_hour == 12)
        {
            displayHour = 12;
            period = "PM";
        }
        else
        {
            displayHour = _hour - 12;
            period = "PM";
        }

        return $"{displayHour:00}:{_minute:00}:{_second:00}.{_millisecond:000} {period}";
    }

    public double ToMilliseconds()
    {
        return _millisecond + (_second * 1000) + (_minute * 60000) + (_hour * 3600000);
    }
    public double ToMinutes()
    {
        return (_hour * 60) + _minute + (_second / 60) + (_millisecond / 60000);
    }
    public double ToSeconds()
    {
        return (_hour * 3600) + (_minute * 60) + _second + (_millisecond / 1000);
    }

    private int ValidHour (int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour: {hour}, is not valid.");
        }
        return hour;
    }
    private int ValidMillisecond (int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The millisecond: {millisecond}, is not valid.");
        }
        return millisecond;
    }

    private int ValidMinute (int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute: {minute}, is not valid.");
        }
        return minute;
    }
    private int ValidSecond (int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second: {second}, is not valid.");
        }
        return second;
    }

    public Time Add(Time input)
    {
        int newHour = _hour + input._hour;
        int newMinute = _minute + input._minute;
        int newSecond = _second + input._second;
        int newMillisecond = _millisecond + input._millisecond;

        if (newMillisecond > 999)
        {
            newSecond += newMillisecond / 1000;
            newMillisecond = newMillisecond % 1000;
        }

        if (newSecond > 59)
        {
            newMinute += newSecond / 60;
            newSecond = newSecond % 60;
        }

        if (newMinute > 59)
        {
            newHour += newMinute / 60;
            newMinute = newMinute % 60;
        }
        if (newHour > 23)
        {
            newHour = newHour % 24;
        }
        return new Time(newHour, newMinute, newSecond, newMillisecond);
    }
    public bool IsOtherDay(Time input)
    {
        int totalHours = this._hour + input._hour;
        return totalHours >= 24;
    }


}
