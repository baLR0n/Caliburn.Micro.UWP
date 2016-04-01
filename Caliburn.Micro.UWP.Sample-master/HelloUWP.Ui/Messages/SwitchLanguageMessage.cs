namespace Caliburn.Micro.HelloUWP.Ui.Messages
{
    public class SwitchLanguageMessage
    {
        /// <summary>
        /// Gets or sets the new language.
        /// </summary>
        /// <value>The new language.</value>
        public string NewLanguage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchLanguageMessage"/> class.
        /// </summary>
        /// <param name="newLanguage">The new language.</param>
        public SwitchLanguageMessage(string newLanguage)
        {
            this.NewLanguage = newLanguage;
        }
    }
}
