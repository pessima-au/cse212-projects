using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // Accumulate points for each player
            if (players.ContainsKey(playerId))
                players[playerId] += points;
            else
                players[playerId] = points;
        }

        // Players by total points descending
        var topPlayers = players.OrderByDescending(p => p.Value)
                               .Take(10)
                               .ToArray();

        // Top 10 players
        Console.WriteLine("Top 10 Players by Career Points:");
        Console.WriteLine("PlayerID\tTotalPoints");
        foreach (var player in topPlayers)
        {
            Console.WriteLine($"{player.Key}\t{player.Value}");
        }
    }
}