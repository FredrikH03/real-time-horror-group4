using Npgsql;
namespace real_time_horror_group4;

public class GetQuestions
{
    private readonly NpgsqlDataSource _db;
    public GetQuestions(NpgsqlDataSource db)
    {
        _db = db;
    }

    public async Task GetRandomQuestion(string test)
    {
        int maxNum = 0;
        string question = "failed";
        string answer = "test";

        Random random = new Random();
        int num = random.Next(1, 31);

        await using var getQuestions = _db.CreateCommand("SELECT questions FROM Questions WHERE ID = $1");
        getQuestions.Parameters.AddWithValue(num);
        await using var reader = await getQuestions.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            question = reader.GetString(0);
        }

        string returnString = "the question is as follows: " + question;
        test = returnString;
        /*
        string userInput = Console.ReadLine();


        await using var getAnswer =
            _db.CreateCommand("SELECT answer FROM CorrectAnswers WHERE questionid = $1 AND answer = $2");
                getAnswer.Parameters.AddWithValue(num);
            getAnswer.Parameters.AddWithValue(userInput);
        await using var reader2 = await getAnswer.ExecuteReaderAsync();
        while (await reader2.ReadAsync())
        {
            answer = reader2.GetString(0);
        }
        //Console.WriteLine(answer);
        Console.WriteLine("your guess is...");
        Thread.Sleep(1000);
        if (answer == "test")
        {
            Console.WriteLine("wrong!!!");
        }
        else
        {
            Console.WriteLine("Correct!!!");
        }
        */
    }

}