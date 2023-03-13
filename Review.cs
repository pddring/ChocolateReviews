using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateReviews
{
    class Review
    {
        public int ReviewID;
        public int ChocolateBarID;
        public int UserID;
        public int Score;
        public string Comment;

        /// <summary>
        /// Create a new review object
        /// </summary>
        /// <param name="ReviewID">Review ID</param>
        /// <param name="ChocolateBarID">ID of chocolate bar</param>
        /// <param name="UserID">ID of user who wrote the review</param>
        /// <param name="Score">Review score (out of 5)</param>
        /// <param name="Comment">Optional comment</param>
        public Review(int ReviewID, int ChocolateBarID, int UserID, int Score, string Comment)
        {
            this.ReviewID = ReviewID;
            this.ChocolateBarID = ChocolateBarID;
            this.UserID = UserID;
            this.Score = Score;
            this.Comment = Comment;
        }

        /// <summary>
        /// Create a new review object from a SQL reader
        /// </summary>
        /// <param name="r">SqlDataReader object (read from a database)</param>
        public Review(SqlDataReader r)
        {
            ReviewID = (int)r["ReviewID"];
            ChocolateBarID = (int)r["ChocolateBarID"];
            UserID = (int)r["UserID"];
            Score = (int)r["Score"];
            Comment = (string)r["Comment"];
        }

        public override string ToString()
        {
            return $"ReviewID: {ReviewID}   ChocolateBarID: {ChocolateBarID}    UserID: {UserID}    Score: {Score}  Comment: {Comment}";
        }
    }
}
