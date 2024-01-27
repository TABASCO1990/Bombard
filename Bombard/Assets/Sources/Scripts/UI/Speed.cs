namespace UI
{
    public class Speed : View
    {
        private void OnEnable()
        {
            EnableAction(_spawner.ChangeSpeed);
        }

        private void OnDisable()
        {
            DisableAction(_spawner.ChangeSpeed);
        }
    }
}
