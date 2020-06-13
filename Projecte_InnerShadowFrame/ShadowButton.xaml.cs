using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projecte_InnerShadowFrame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShadowButton : ContentView
    {
        #region .: Properties :.

        private Color ButtonPressedColor { get; set; }

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public Color PressedColor
        {
            get { return (Color)GetValue(PressedColorProperty); }
            set { SetValue(PressedColorProperty, value); }
        }

        public float ShadowSize
        {
            get { return (float)GetValue(ShadowSizeProperty); }
            set { SetValue(ShadowSizeProperty, value); }
        }

        public float ShadowMargin
        {
            get { return (float)GetValue(ShadowMarginProperty); }
            set { SetValue(ShadowMarginProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        #endregion

        #region .: Bindable Properties :.

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(InnerShadowLayout), Color.White,
                propertyChanged: OnBackgroundColorPropertyChanged);

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(InnerShadowLayout), null,
                propertyChanged: OnCommandPropertyChanged);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(InnerShadowLayout), null,
                propertyChanged: OnCommandParameterPropertyChanged);

        public static readonly BindableProperty PressedColorProperty =
            BindableProperty.Create(nameof(PressedColor), typeof(Color), typeof(InnerShadowLayout), Color.White,
                propertyChanged: OnPressedColorPropertyChanged);

        public static readonly BindableProperty ShadowSizeProperty =
            BindableProperty.Create(nameof(ShadowSize), typeof(float), typeof(InnerShadowLayout), 10.0f,
                propertyChanged: OnShadowSizePropertyChanged);

        public static readonly BindableProperty ShadowMarginProperty =
            BindableProperty.Create(nameof(ShadowMargin), typeof(float), typeof(InnerShadowLayout), 10.0f,
                propertyChanged: OnShadowMarginPropertyChanged);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(InnerShadowLayout), string.Empty,
                propertyChanged: OnTextPropertyChanged);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(InnerShadowLayout), Color.Black,
                propertyChanged: OnTextColorPropertyChanged);

        #endregion

        #region .: Property Changed's :.

        private static void OnBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ShadowButton)bindable;
            if(newValue is Color color)
            {
                control.ShadowLayoutElement.BackgroundColor = color;
            }
        }

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ShadowButton)bindable;
            if (newValue is ICommand command)
            {
                control.ButtonElement.Command = command;
            }
        }

        private static void OnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ShadowButton)bindable;
            if (newValue is object commandParameter)
            {
                control.ButtonElement.CommandParameter = commandParameter;
            }
        }

        private static void OnPressedColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ShadowButton)bindable;
            if (newValue is Color color)
            {
                control.ButtonPressedColor = color;
            }
        }

        private static void OnShadowSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ShadowButton)bindable;
            if (newValue is float intesnity)
            {
                control.ShadowLayoutElement.ShadowMaskSigma = intesnity;
            }
        }

        private static void OnShadowMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ShadowButton)bindable;
            if (newValue is float size)
            {
                control.ShadowLayoutElement.ShadowSize = size;
            }
        }

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ShadowButton)bindable;
            if (newValue is string text)
            {
                control.ButtonElement.Text = text;
            }
        }

        private static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ShadowButton)bindable;
            if (newValue is Color color)
            {
                control.ButtonElement.TextColor = color;
            }
        }

        #endregion

        #region .: Constructor :.

        public ShadowButton()
        {
            InitializeComponent();
        }

        #endregion

        #region .: Events :.

        private async void Button_Pressed(object sender, EventArgs e)
        {
            await Task.Run(async () => await Task.Delay(100));
            ButtonElement.BackgroundColor = ButtonPressedColor;
        }

        private async void ButtonElement_Released(object sender, EventArgs e)
        {
            await Task.Run(async () => await Task.Delay(100));
            ButtonElement.BackgroundColor = Color.Transparent;
        }

        #endregion
    }
}