namespace SAEView.ROOT.CIMV2 {
    using System;
    using System.ComponentModel;
    using System.Management;
    using System.Collections;
    using System.Globalization;
    using System.ComponentModel.Design.Serialization;
    using System.Reflection;
    
    
    // Las funciones ShouldSerialize<PropertyName> son funciones que utiliza el Examinador de propiedades de VS para comprobar si se tiene que serializar una propiedad determinada. Estas funciones se agregan para todas las propiedades ValueType (propiedades de tipo Int32, BOOL etc. que no se pueden establecer como NULL). Estas funciones utilizan la función Is<PropertyName>Null. Asimismo, se utilizan en la implementación de TypeConverter para que las propiedades comprueben el valor NULL de una propiedad, de modo que se pueda mostrar un valor vacío en el Examinador de propiedades si se utiliza la función de arrastrar y colocar en Visual Studio.
    // Las funciones Is<PropertyName>Null() se utilizan para comprobar si una propiedad tiene valores NULL.
    // Las funciones Reset<PropertyName> se agregan para las propiedades Nullable Read/Write. El diseñador de VS utiliza estas funciones en el Examinador de propiedades para establecer una propiedad como NULL.
    // Todas las propiedades que se agregan a la clase de la propiedad WMI tienen atributos establecidos para definir su comportamiento en el diseñador de Visual Studio, así como para definir el elemento TypeConverter que se debe utilizar.
    // Las funciones Datetime de conversión ToDateTime y ToDmtfDateTime se agregan a la clase para convertir la fecha y hora DMTF a System.DateTime y viceversa.
    // Se generó una clase Early Bound para la clase WMI.Win32_Printer
    public class Printer : System.ComponentModel.Component {
        
        // Propiedad privada que contiene el espacio de nombres WMI en el que reside la clase.
        private static string CreatedWmiNamespace = "ROOT\\CIMV2";
        
        // Propiedad privada que mantiene el nombre de la clase WMI, que creó esta clase.
        private static string CreatedClassName = "Win32_Printer";
        
        // Variable miembro privada que contiene el valor ManagementScope que utilizan los diferentes métodos.
        private static System.Management.ManagementScope statMgmtScope = null;
        
        private ManagementSystemProperties PrivateSystemProperties;
        
        // Objeto lateBound de WMI subyacente.
        private System.Management.ManagementObject PrivateLateBoundObject;
        
        // Variable miembro que almacena el comportamiento de 'confirmación automática' de la clase.
        private bool AutoCommitProp;
        
        // Variable privada que contiene la propiedad incrustada que representa la instancia.
        private System.Management.ManagementBaseObject embeddedObj;
        
        // Objeto WMI actual utilizado
        private System.Management.ManagementBaseObject curObj;
        
        // Etiqueta para indicar si la instancia es un objeto incrustado.
        private bool isEmbedded;
        
        // A continuación se muestran las diferentes sobrecargas de constructores para inicializar una instancia de la clase con un objeto WMI.
        public Printer() {
            this.InitializeObject(null, null, null);
        }
        
        public Printer(string keyDeviceID) {
            this.InitializeObject(null, new System.Management.ManagementPath(Printer.ConstructPath(keyDeviceID)), null);
        }
        
        public Printer(System.Management.ManagementScope mgmtScope, string keyDeviceID) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(Printer.ConstructPath(keyDeviceID)), null);
        }
        
        public Printer(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public Printer(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public Printer(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public Printer(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public Printer(System.Management.ManagementObject theObject) {
            Initialize();
            if ((CheckIfProperClass(theObject) == true)) {
                PrivateLateBoundObject = theObject;
                PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
                curObj = PrivateLateBoundObject;
            }
            else {
                throw new System.ArgumentException("El nombre de clase no coincide.");
            }
        }
        
        public Printer(System.Management.ManagementBaseObject theObject) {
            Initialize();
            if ((CheckIfProperClass(theObject) == true)) {
                embeddedObj = theObject;
                PrivateSystemProperties = new ManagementSystemProperties(theObject);
                curObj = embeddedObj;
                isEmbedded = true;
            }
            else {
                throw new System.ArgumentException("El nombre de clase no coincide.");
            }
        }
        
        // La propiedad devuelve el espacio de nombres de la clase WMI.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OriginatingNamespace {
            get {
                return "ROOT\\CIMV2";
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ManagementClassName {
            get {
                string strRet = CreatedClassName;
                if ((curObj != null)) {
                    if ((curObj.ClassPath != null)) {
                        strRet = ((string)(curObj["__CLASS"]));
                        if (((strRet == null) 
                                    || (strRet == string.Empty))) {
                            strRet = CreatedClassName;
                        }
                    }
                }
                return strRet;
            }
        }
        
        // Propiedad que señala a un objeto incrustado para obtener las propiedades System del objeto WMI.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManagementSystemProperties SystemProperties {
            get {
                return PrivateSystemProperties;
            }
        }
        
        // Propiedad que devuelve el objeto lateBound subyacente.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Management.ManagementBaseObject LateBoundObject {
            get {
                return curObj;
            }
        }
        
        // ManagementScope del objeto.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Management.ManagementScope Scope {
            get {
                if ((isEmbedded == false)) {
                    return PrivateLateBoundObject.Scope;
                }
                else {
                    return null;
                }
            }
            set {
                if ((isEmbedded == false)) {
                    PrivateLateBoundObject.Scope = value;
                }
            }
        }
        
        // Propiedad que muestra el comportamiento de confirmación del objeto WMI. Si se establece como true, el objeto WMI se guarda automáticamente después de modificar cada propiedad. Por ejemplo: se llama a Put() después de modificar una propiedad.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoCommit {
            get {
                return AutoCommitProp;
            }
            set {
                AutoCommitProp = value;
            }
        }
        
        // ManagementPath del objeto WMI subyacente.
        [Browsable(true)]
        public System.Management.ManagementPath Path {
            get {
                if ((isEmbedded == false)) {
                    return PrivateLateBoundObject.Path;
                }
                else {
                    return null;
                }
            }
            set {
                if ((isEmbedded == false)) {
                    if ((CheckIfProperClass(null, value, null) != true)) {
                        throw new System.ArgumentException("El nombre de clase no coincide.");
                    }
                    PrivateLateBoundObject.Path = value;
                }
            }
        }
        
        // Propiedad pública de ámbito estático que utilizan los diferentes métodos.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static System.Management.ManagementScope StaticScope {
            get {
                return statMgmtScope;
            }
            set {
                statMgmtScope = value;
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAttributesNull {
            get {
                if ((curObj["Attributes"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The Attributes property indicates the attributes of the Win32 printing device. These attributes are represented through a combination of flags. Attributes of the printer include:
Queued  - Print jobs are buffered and queued.
 Direct  - Specifies that the document should be sent directly to the printer.  This is used if print job are not being properly queued.
Default - The printer is the default printer on the computer.
Shared - Available as a shared network resource.
Network - Attached to the network.
Hidden - Hidden from some users on the network.
Local - Directly connected to this computer.
EnableDevQ - Enable the queue on the printer if available.
KeepPrintedJobs - Specifies that the spooler should not delete documents after they are printed.
DoCompleteFirst - Start jobs that are finished spooling first.
WorkOffline - Queue print jobs when printer is not available.
EnableBIDI - Enable bi-directional printing.
RawOnly - Allow only raw data type jobs to be spooled.
Published - Indicates whether the printer is published in the network directory service.
")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public AttributesValues Attributes {
            get {
                if ((curObj["Attributes"] == null)) {
                    return ((AttributesValues)(System.Convert.ToInt32(16384)));
                }
                return ((AttributesValues)(System.Convert.ToInt32(curObj["Attributes"])));
            }
            set {
                if ((AttributesValues.NULL_ENUM_VALUE == value)) {
                    curObj["Attributes"] = null;
                }
                else {
                    curObj["Attributes"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAvailabilityNull {
            get {
                if ((curObj["Availability"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"La disponibilidad y estado del dispositivo. Por ejemplo, la propiedad disponibilidad, indica que el dispositivo está en funcionamiento y tiene energía total (valor=3), o se encuentra en un estado de aviso (4), prueba (5), degradado (10) o ahorro de energía (valores 13-15 y 17). En relación con los estados de ahorro de energía, éstos se definen como sigue: Valor 13 (""Ahorro de energía: desconocido"") indica que se sabe que el dispositivo está en un modo de ahorro de energía, pero se desconoce su estado exacto en este modo; 14 (""Ahorro de energía: modo de bajo consumo"") indica que el dispositivo está en un estado de  ahorro de energía, pero sigue funcionando y puede exhibir una baja de rendimiento;  15 (""Ahorro de energía: espera"") describe que el sistema no está en funcionamiento, pero que se podría poner en operación ""rápidamente""; y valor 17 (""Ahorro de energía: advertencia"") indica que el equipo está en un estado de aviso, aunque está también en modo de ahorro de energía.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public AvailabilityValues Availability {
            get {
                if ((curObj["Availability"] == null)) {
                    return ((AvailabilityValues)(System.Convert.ToInt32(0)));
                }
                return ((AvailabilityValues)(System.Convert.ToInt32(curObj["Availability"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Describe todos las hojas de trabajo que están disponibles en la impresora. También puede usarse para describir la pancarta que la impresora puede proporcionar al inicio de cada trabajo, o también puede describir las opciones especificadas por otros usuarios.")]
        public string[] AvailableJobSheets {
            get {
                return ((string[])(curObj["AvailableJobSheets"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAveragePagesPerMinuteNull {
            get {
                if ((curObj["AveragePagesPerMinute"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The AveragePagesPerMinute property specifies the rate (average number of pages pe" +
            "r minute) that the printer is capable of sustaining.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint AveragePagesPerMinute {
            get {
                if ((curObj["AveragePagesPerMinute"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["AveragePagesPerMinute"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Una matriz de enteros que indica capacidades de impresora. Se especifica informac" +
            "ión como \"Impresión a doble cara\" (valor=3) o \"Impresión de transparencia\" (7).")]
        public CapabilitiesValues[] Capabilities {
            get {
                System.Array arrEnumVals = ((System.Array)(curObj["Capabilities"]));
                CapabilitiesValues[] enumToRet = new CapabilitiesValues[arrEnumVals.Length];
                int counter = 0;
                for (counter = 0; (counter < arrEnumVals.Length); counter = (counter + 1)) {
                    enumToRet[counter] = ((CapabilitiesValues)(System.Convert.ToInt32(arrEnumVals.GetValue(counter))));
                }
                return enumToRet;
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Una matriz de cadenas de forma libre que proporcionan explicaciones más detalladas para cualquiera de las características indicadas en la matriz de capacidades. Nota, cada entrada de esta matriz está relacionada a la entrada de la matriz de capacidades que está ubicada en el mismo índice.")]
        public string[] CapabilityDescriptions {
            get {
                return ((string[])(curObj["CapabilityDescriptions"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption {
            get {
                return ((string)(curObj["Caption"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Identifica los juegos de caracteres disponibles para el texto de salida relacionado con la información de administración de la impresora. Las cadenas proporcionadas en esta propiedad deben guardar las normas semánticas y sintácticas especificadas en la sección 4.1.2 (""Charset parameter"") en RFC 2046 (MIME Part 2), contenida en el Registro de juego de caracteres IANA. Por ejemplo, ""utf-8"", ""us-ascii"" y ""iso-8859-1"".")]
        public string[] CharSetsSupported {
            get {
                return ((string[])(curObj["CharSetsSupported"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Comment property specifies the comment of a print queue.\nExample: Color print" +
            "er")]
        public string Comment {
            get {
                return ((string)(curObj["Comment"]));
            }
            set {
                curObj["Comment"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsConfigManagerErrorCodeNull {
            get {
                if ((curObj["ConfigManagerErrorCode"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indica el código de error del Administrador de configuración de Win32. Los valore" +
            "s siguientes pueden ser devueltos: \n0 Este dispositivo funciona correctamente. \n" +
            "1 Este dispositivo no está configurado correctamente. \n2 Windows no puede cargar" +
            " el controlador para este dispositivo. \n3 El controlador de este dispositivo pue" +
            "de estar dañado o le falta memoria o recursos a su sistema. \n4 Este dispositivo " +
            "no funciona correctamente. Uno de sus controladores o el Registro pueden estar d" +
            "añados. \n5 El controlador de este dispositivo necesita un recurso que Windows no" +
            " puede administrar. \n6 La configuración de arranque de este dispositivo entra en" +
            " conflicto con otros dispositivos. \n7 No se puede filtrar. \n8 Falta el cargador " +
            "de controlador del dispositivo. \n9 Este dispositivo no funciona correctamente po" +
            "rque el firmware de control está informando incorrectamente acerca de los recurs" +
            "os del dispositivo. \n10 El dispositivo no puede se iniciar. \n11 Error en el disp" +
            "ositivo. \n12 Este dispositivo no encuentra suficientes recursos libres para usar" +
            ". \n13 Windows no puede comprobar los recursos de este dispositivo. \n14 Este disp" +
            "ositivo no funcionará correctamente hasta que reinicie su equipo. \n15 Este dispo" +
            "sitivo no funciona correctamente porque hay un posible problema de enumeración. " +
            "\n16 Windows no puede identificar todos los recursos que utiliza este dispositivo" +
            ". \n17 Este dispositivo está solicitando un tipo de recurso desconocido. \n18 Vuel" +
            "va a instalar los controladores de este dispositivo \n19 Su Registro debe estar d" +
            "añado. \n20 Error usar el cargador VxD. \n21 Error del sistema: intente cambiar el" +
            " controlador de este dispositivo. Si esto no funciona, consulte la documentación" +
            " de hardware. Windows está quitando este dispositivo. \n22 Este dispositivo está " +
            "deshabilitado. \n23 Error del sistema: intente cambiar el controlador de este dis" +
            "positivo. Si esto no funciona, consulte la documentación de hardware. \n24 Este d" +
            "ispositivo no está presente, no funciona correctamente o no tiene todos los cont" +
            "roladores instalados. \n25 Windows aún está instalando este dispositivo. \n26 Wind" +
            "ows aún está instalando este dispositivo. \n27 Este dispositivo no tiene una conf" +
            "iguración de Registro válida. \n28 Los controladores de este dispositivo no están" +
            " instalados. \n29 Este dispositivo está deshabilitado porque el firmware no propo" +
            "rcionó los recursos requeridos. \n30 Este dispositivo está utilizando una recurso" +
            " de solicitud de interrupción (IRQ) que ya está usando otro dispositivo. \n31 Est" +
            "e dispositivo no funciona correctamente porque Windows no puede cargar los contr" +
            "oladores requeridos.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ConfigManagerErrorCodeValues ConfigManagerErrorCode {
            get {
                if ((curObj["ConfigManagerErrorCode"] == null)) {
                    return ((ConfigManagerErrorCodeValues)(System.Convert.ToInt32(32)));
                }
                return ((ConfigManagerErrorCodeValues)(System.Convert.ToInt32(curObj["ConfigManagerErrorCode"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsConfigManagerUserConfigNull {
            get {
                if ((curObj["ConfigManagerUserConfig"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indica si el dispositivo usa una configuración predefinida por el usuario.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool ConfigManagerUserConfig {
            get {
                if ((curObj["ConfigManagerUserConfig"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["ConfigManagerUserConfig"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"CreationClassName indica el nombre de la clase o subclase que se usa en la creación de una instancia. Cuando se usa con las demás propiedades clave de esta clase, esta propiedad permite que se identifiquen de manera única todas las instancias de esta clase y sus subclases.")]
        public string CreationClassName {
            get {
                return ((string)(curObj["CreationClassName"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Especifica qué capacidades de acabado y otras de la impresora se están utilizando" +
            " actualmente. Una entrada en esta propiedad debería listarse también en la matri" +
            "z de capacidades.")]
        public CurrentCapabilitiesValues[] CurrentCapabilities {
            get {
                System.Array arrEnumVals = ((System.Array)(curObj["CurrentCapabilities"]));
                CurrentCapabilitiesValues[] enumToRet = new CurrentCapabilitiesValues[arrEnumVals.Length];
                int counter = 0;
                for (counter = 0; (counter < arrEnumVals.Length); counter = (counter + 1)) {
                    enumToRet[counter] = ((CurrentCapabilitiesValues)(System.Convert.ToInt32(arrEnumVals.GetValue(counter))));
                }
                return enumToRet;
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Especifica el juego de caracteres usado actualmente por el texto de salida relacionado con la información de administración de la impresora. El juego de caracteres descrito en esta propiedad también debería listarse en la propiedad CharsetsSupported. La cadena especificada en esta propiedad debe guardar las normas semánticas y sintácticas especificadas en la sección 4.1.2 (""Charset parameter"") en RFC 2046 (MIME Part 2), contenida en el Registro de juego de caracteres IANA. Por ejemplo, ""utf-8"", ""us-ascii"" y ""iso-8859-1"".")]
        public string CurrentCharSet {
            get {
                return ((string)(curObj["CurrentCharSet"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCurrentLanguageNull {
            get {
                if ((curObj["CurrentLanguage"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indica el idioma de impresión actualmente en uso. Todo idioma usado por la impres" +
            "ora debería estar listado también en la propiedad LanguagesSupported.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public CurrentLanguageValues CurrentLanguage {
            get {
                if ((curObj["CurrentLanguage"] == null)) {
                    return ((CurrentLanguageValues)(System.Convert.ToInt32(0)));
                }
                return ((CurrentLanguageValues)(System.Convert.ToInt32(curObj["CurrentLanguage"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Especifica el tipo MIME que está usando actualmente la impresora si se estableció" +
            " la propiedad CurrentLanguage para indicar que se está usando un tipo MIME (valo" +
            "r = 47).")]
        public string CurrentMimeType {
            get {
                return ((string)(curObj["CurrentMimeType"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Identifica el idioma usado actualmente por la impresora para mantenimiento. El id" +
            "ioma listado en la propiedad CurrentNaturalLanguage también debe estar en la pro" +
            "piedad NaturalLanguagesSupported.")]
        public string CurrentNaturalLanguage {
            get {
                return ((string)(curObj["CurrentNaturalLanguage"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Especifica el tipo de papel que la impresora está usando actualmente. La cadena d" +
            "ebe estar expresada de acuerdo al formato de ISO/IEC 10175 Document Printing App" +
            "lication (DPA) que también está resumido en el apéndice C de RFC 1759 (Printe MI" +
            "B).")]
        public string CurrentPaperType {
            get {
                return ((string)(curObj["CurrentPaperType"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefaultNull {
            get {
                if ((curObj["Default"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Default property indicates whether the printer is the default printer on the " +
            "computer.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Default {
            get {
                if ((curObj["Default"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Default"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Especifica qué capacidades de acabado y otras de la impresora se utilizarán de fo" +
            "rma predeterminada. Una entrada en la propiedad DefaultCapabilities debería list" +
            "arse también en la matriz de capacidades.")]
        public DefaultCapabilitiesValues[] DefaultCapabilities {
            get {
                System.Array arrEnumVals = ((System.Array)(curObj["DefaultCapabilities"]));
                DefaultCapabilitiesValues[] enumToRet = new DefaultCapabilitiesValues[arrEnumVals.Length];
                int counter = 0;
                for (counter = 0; (counter < arrEnumVals.Length); counter = (counter + 1)) {
                    enumToRet[counter] = ((DefaultCapabilitiesValues)(System.Convert.ToInt32(arrEnumVals.GetValue(counter))));
                }
                return enumToRet;
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefaultCopiesNull {
            get {
                if ((curObj["DefaultCopies"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("El número de copias que se pueden hacer en un solo trabajo a menos que se especif" +
            "ique lo contrario.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint DefaultCopies {
            get {
                if ((curObj["DefaultCopies"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["DefaultCopies"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefaultLanguageNull {
            get {
                if ((curObj["DefaultLanguage"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indica el idioma predeterminado de la impresora. Todo idioma que es usado de form" +
            "a predeterminada por la impresora debe estar listado en LanguagesSupported.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public DefaultLanguageValues DefaultLanguage {
            get {
                if ((curObj["DefaultLanguage"] == null)) {
                    return ((DefaultLanguageValues)(System.Convert.ToInt32(0)));
                }
                return ((DefaultLanguageValues)(System.Convert.ToInt32(curObj["DefaultLanguage"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Especifica el tipo MIME predeterminado usado por la impresora si se estableció la" +
            " propiedad DefaultLanguage para indicar que se esta usando un tipo MIME (valor =" +
            " 47).")]
        public string DefaultMimeType {
            get {
                return ((string)(curObj["DefaultMimeType"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefaultNumberUpNull {
            get {
                if ((curObj["DefaultNumberUp"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("El número de páginas de impresión transmitida (print-stream) que la impresora pue" +
            "de representar en una sola hoja a menos que se especifique lo contrario en un tr" +
            "abajo.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint DefaultNumberUp {
            get {
                if ((curObj["DefaultNumberUp"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["DefaultNumberUp"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Especifica el tipo de papel que usará la impresora si PrintJob no especifica un tipo en particular. La cadena se debe expresar en la forma especificada por Aplicación de impresión de documentos (DPA) ISO/IEC 10175 que se resume también en el apéndice C de RFC 1759 (Printer MIB).")]
        public string DefaultPaperType {
            get {
                return ((string)(curObj["DefaultPaperType"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefaultPriorityNull {
            get {
                if ((curObj["DefaultPriority"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The DefaultPriority property specifies the default priority value assigned to eac" +
            "h print job.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint DefaultPriority {
            get {
                if ((curObj["DefaultPriority"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["DefaultPriority"]));
            }
            set {
                curObj["DefaultPriority"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description {
            get {
                return ((string)(curObj["Description"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDetectedErrorStateNull {
            get {
                if ((curObj["DetectedErrorState"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Información de error de impresora.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public DetectedErrorStateValues DetectedErrorState {
            get {
                if ((curObj["DetectedErrorState"] == null)) {
                    return ((DetectedErrorStateValues)(System.Convert.ToInt32(12)));
                }
                return ((DetectedErrorStateValues)(System.Convert.ToInt32(curObj["DetectedErrorState"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("DeviceID es una dirección u otra información de identificación que da un nombre ú" +
            "nico al dispositivo lógico.")]
        public string DeviceID {
            get {
                return ((string)(curObj["DeviceID"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDirectNull {
            get {
                if ((curObj["Direct"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Direct property indicates whether the print jobs should be sent directly to t" +
            "he printer.  This means that no spool files are created for the print jobs.\n")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Direct {
            get {
                if ((curObj["Direct"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Direct"]));
            }
            set {
                curObj["Direct"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDoCompleteFirstNull {
            get {
                if ((curObj["DoCompleteFirst"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The DoCompleteFirst property indicates whether the printer should start jobs that" +
            " have finished spooling as opposed to the order of the job received.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool DoCompleteFirst {
            get {
                if ((curObj["DoCompleteFirst"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["DoCompleteFirst"]));
            }
            set {
                curObj["DoCompleteFirst"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The DriverName property specifies the name of the Win32 printer driver.\nExample: " +
            "Windows NT Fax Driver")]
        public string DriverName {
            get {
                return ((string)(curObj["DriverName"]));
            }
            set {
                curObj["DriverName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEnableBIDINull {
            get {
                if ((curObj["EnableBIDI"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The EnableBIDI property indicates whether the printer can print bidirectionally.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool EnableBIDI {
            get {
                if ((curObj["EnableBIDI"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["EnableBIDI"]));
            }
            set {
                curObj["EnableBIDI"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEnableDevQueryPrintNull {
            get {
                if ((curObj["EnableDevQueryPrint"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The EnableDevQueryPrint property indicates whether to hold documents in the queue" +
            ", if document and printer setups do not match")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool EnableDevQueryPrint {
            get {
                if ((curObj["EnableDevQueryPrint"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["EnableDevQueryPrint"]));
            }
            set {
                curObj["EnableDevQueryPrint"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsErrorClearedNull {
            get {
                if ((curObj["ErrorCleared"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("ErrorCleared es una propiedad booleana que indica que el error comunicado en la p" +
            "ropiedad LastErrorCode se ha resuelto ahora.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool ErrorCleared {
            get {
                if ((curObj["ErrorCleared"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["ErrorCleared"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("ErrorDescription es una cadena de forma libre que ofrece más información acerca d" +
            "el error registrado en la propiedad LastErrorCode e información acerca de cualqu" +
            "ier acción correctiva que se pueda tomar.")]
        public string ErrorDescription {
            get {
                return ((string)(curObj["ErrorDescription"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Una matriz que proporciona información adicional sobre el estado de error actual " +
            "indicado en DetectedErrorState.")]
        public string[] ErrorInformation {
            get {
                return ((string[])(curObj["ErrorInformation"]));
            }
            set {
                curObj["ErrorInformation"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsExtendedDetectedErrorStateNull {
            get {
                if ((curObj["ExtendedDetectedErrorState"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The ExtendedDetectedErrorState property reports standard error information.  Any " +
            "additional information should be recorded in the DetecteErrorState property.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ExtendedDetectedErrorStateValues ExtendedDetectedErrorState {
            get {
                if ((curObj["ExtendedDetectedErrorState"] == null)) {
                    return ((ExtendedDetectedErrorStateValues)(System.Convert.ToInt32(16)));
                }
                return ((ExtendedDetectedErrorStateValues)(System.Convert.ToInt32(curObj["ExtendedDetectedErrorState"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsExtendedPrinterStatusNull {
            get {
                if ((curObj["ExtendedPrinterStatus"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Status information for a Printer, beyond that specified in the LogicalDevice Avai" +
            "lability property. Values include \"Idle\" (3) and an indication that the Device i" +
            "s currently printing (4).")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ExtendedPrinterStatusValues ExtendedPrinterStatus {
            get {
                if ((curObj["ExtendedPrinterStatus"] == null)) {
                    return ((ExtendedPrinterStatusValues)(System.Convert.ToInt32(0)));
                }
                return ((ExtendedPrinterStatusValues)(System.Convert.ToInt32(curObj["ExtendedPrinterStatus"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHiddenNull {
            get {
                if ((curObj["Hidden"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Hidden property indicates whether the printer is hidden from network users.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Hidden {
            get {
                if ((curObj["Hidden"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Hidden"]));
            }
            set {
                curObj["Hidden"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHorizontalResolutionNull {
            get {
                if ((curObj["HorizontalResolution"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Resolución horizontal de la impresora en píxeles por pulgada.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint HorizontalResolution {
            get {
                if ((curObj["HorizontalResolution"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["HorizontalResolution"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsInstallDateNull {
            get {
                if ((curObj["InstallDate"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime InstallDate {
            get {
                if ((curObj["InstallDate"] != null)) {
                    return ToDateTime(((string)(curObj["InstallDate"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsJobCountSinceLastResetNull {
            get {
                if ((curObj["JobCountSinceLastReset"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Trabajos de la impresora procesados desde el último restablecimiento. Es posible " +
            "que estos trabajos se hayan procesado desde una o más colas de impresión.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint JobCountSinceLastReset {
            get {
                if ((curObj["JobCountSinceLastReset"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["JobCountSinceLastReset"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsKeepPrintedJobsNull {
            get {
                if ((curObj["KeepPrintedJobs"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The KeepPrintedJobs property indicates whether the print spooler should not delet" +
            "e the jobs after they are completed.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool KeepPrintedJobs {
            get {
                if ((curObj["KeepPrintedJobs"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["KeepPrintedJobs"]));
            }
            set {
                curObj["KeepPrintedJobs"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Una matriz indicando los idiomas nativos de impresión compatibles.")]
        public LanguagesSupportedValues[] LanguagesSupported {
            get {
                System.Array arrEnumVals = ((System.Array)(curObj["LanguagesSupported"]));
                LanguagesSupportedValues[] enumToRet = new LanguagesSupportedValues[arrEnumVals.Length];
                int counter = 0;
                for (counter = 0; (counter < arrEnumVals.Length); counter = (counter + 1)) {
                    enumToRet[counter] = ((LanguagesSupportedValues)(System.Convert.ToInt32(arrEnumVals.GetValue(counter))));
                }
                return enumToRet;
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLastErrorCodeNull {
            get {
                if ((curObj["LastErrorCode"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("LastErrorCode captura el último código de error informado por el dispositivo lógi" +
            "co.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint LastErrorCode {
            get {
                if ((curObj["LastErrorCode"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["LastErrorCode"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLocalNull {
            get {
                if ((curObj["Local"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The Local property indicates whether the printer is attached to the network.  A masquerading printer is printer that is implemented as local printers but has a port that refers to a remote machine.  From the application perspective these hybrid printers should be viewed as printer connections since that is their intended behavior.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Local {
            get {
                if ((curObj["Local"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Local"]));
            }
            set {
                curObj["Local"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Location property specifies the physical location of the printer.\nExample: Bl" +
            "dg. 38, Room 1164")]
        public string Location {
            get {
                return ((string)(curObj["Location"]));
            }
            set {
                curObj["Location"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMarkingTechnologyNull {
            get {
                if ((curObj["MarkingTechnology"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Especifica la tecnología usada por la impresora para marcar.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public MarkingTechnologyValues MarkingTechnology {
            get {
                if ((curObj["MarkingTechnology"] == null)) {
                    return ((MarkingTechnologyValues)(System.Convert.ToInt32(0)));
                }
                return ((MarkingTechnologyValues)(System.Convert.ToInt32(curObj["MarkingTechnology"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMaxCopiesNull {
            get {
                if ((curObj["MaxCopies"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("El máximo número de copias que puede hacer una impresora en un solo trabajo de im" +
            "presión.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint MaxCopies {
            get {
                if ((curObj["MaxCopies"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["MaxCopies"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMaxNumberUpNull {
            get {
                if ((curObj["MaxNumberUp"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("El máximo número de páginas de impresión transmitida (print-stream) que la impres" +
            "ora puede representar en una sola hoja.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint MaxNumberUp {
            get {
                if ((curObj["MaxNumberUp"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["MaxNumberUp"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMaxSizeSupportedNull {
            get {
                if ((curObj["MaxSizeSupported"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Especifica el trabajo más grande (como secuencia de bytes) que acepta la impresor" +
            "a expresado en unidades de Kbytes. El valor cero indica que no se han definido l" +
            "ímites.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint MaxSizeSupported {
            get {
                if ((curObj["MaxSizeSupported"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["MaxSizeSupported"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Una matriz de cadenas en formato libre que proporcionan explicaciones más detalladas de todos los tipos MIME que son compatibles con la impresora. Si se proporciona información para esta propiedad, el valor 47,""Mime"" debería estar incluido en la propiedad LanguagesSupported.")]
        public string[] MimeTypesSupported {
            get {
                return ((string[])(curObj["MimeTypesSupported"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Name {
            get {
                return ((string)(curObj["Name"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Identifica los idiomas disponibles para las cadenas que utiliza la impresora al m" +
            "ostrar la información de administración. Las cadenas deben cumplir con las norma" +
            "s de RFC 1766, por ejemplo \"en\" corresponde al idioma inglés.")]
        public string[] NaturalLanguagesSupported {
            get {
                return ((string[])(curObj["NaturalLanguagesSupported"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNetworkNull {
            get {
                if ((curObj["Network"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Network property indicates whether the printer is a network printer.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Network {
            get {
                if ((curObj["Network"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Network"]));
            }
            set {
                curObj["Network"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Una matriz de enteros que indica los tipos de papel compatibles.")]
        public PaperSizesSupportedValues[] PaperSizesSupported {
            get {
                System.Array arrEnumVals = ((System.Array)(curObj["PaperSizesSupported"]));
                PaperSizesSupportedValues[] enumToRet = new PaperSizesSupportedValues[arrEnumVals.Length];
                int counter = 0;
                for (counter = 0; (counter < arrEnumVals.Length); counter = (counter + 1)) {
                    enumToRet[counter] = ((PaperSizesSupportedValues)(System.Convert.ToInt32(arrEnumVals.GetValue(counter))));
                }
                return enumToRet;
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Una matriz de cadenas en formato libre que especifican los tipos de papel que están actualmente disponibles en la impresora. Cada cadena debe estar expresada de acuerdo al ISO/IEC 10175 Document Printing Application (DPA), que también se encuentra resumido en el apéndice C de RFC 1759 (Printer MIB). Por ejemplo, son cadenas válidas: ""iso-a4-colored"" y ""na-10x14-envelope"". Por definición, un tamaño de papel que está disponible y listado en PaperTypesAvailable debería aparecer también en la propiedad PaperSizesSupported.")]
        public string[] PaperTypesAvailable {
            get {
                return ((string[])(curObj["PaperTypesAvailable"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Parameters property specifies optional parameters for the print processor.\nEx" +
            "ample: Copies=2")]
        public string Parameters {
            get {
                return ((string)(curObj["Parameters"]));
            }
            set {
                curObj["Parameters"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indica el id. Plug and Play Win32 del dispositivo lógico. Ejemplo: *PNP030b")]
        public string PNPDeviceID {
            get {
                return ((string)(curObj["PNPDeviceID"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The PortName property identifies the ports that can be used to transmit data to the printer. If a printer is connected to more than one port, the names of each port are separated by commas. Under Windows 95, only one port can be specified. 
Example: LPT1:, LPT2:, LPT3:")]
        public string PortName {
            get {
                return ((string)(curObj["PortName"]));
            }
            set {
                curObj["PortName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Indica los recursos específicos relacionados con energía de dispositivo lógico. Los valores de la matriz, 0=""Desconocido"", 1=""No compatible"" y 2=""Deshabilitado"" se explican por sí solos. El valor 3=""Habilitado"" indica que las características de administración de energía están habilitadas actualmente pero se desconoce el conjunto de características exacto o la información no está disponible. "" Modos de ahorro de energía establecidos automáticamente "" (4) describe que un dispositivo puede cambiar su estado de energía con base en el uso u otros criterios. "" Estado de energía configurable "" (5) indica que se admite el método SetPowerState. "" Ciclo de energía permitido "" (6) indica que se puede invocar el método SetPowerState con la variable de entrada PowerState establecida a 5 (""Ciclo de energía ""). "" Se admite el encendido por tiempo "" (7) indica que el método SetPowerState puede ser invocado con la variable de entrada PowerState establecida  a 5 (""Ciclo de energía "") y el parámetro Time establecido a un fecha y hora específica, o intervalo, para encendido.")]
        public PowerManagementCapabilitiesValues[] PowerManagementCapabilities {
            get {
                System.Array arrEnumVals = ((System.Array)(curObj["PowerManagementCapabilities"]));
                PowerManagementCapabilitiesValues[] enumToRet = new PowerManagementCapabilitiesValues[arrEnumVals.Length];
                int counter = 0;
                for (counter = 0; (counter < arrEnumVals.Length); counter = (counter + 1)) {
                    enumToRet[counter] = ((PowerManagementCapabilitiesValues)(System.Convert.ToInt32(arrEnumVals.GetValue(counter))));
                }
                return enumToRet;
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPowerManagementSupportedNull {
            get {
                if ((curObj["PowerManagementSupported"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Booleano que indica que el Dispositivo se puede administrar con energía - por ej., ponerlo en un estado de ahorro de energía. Este booleano no indica que las características de administración de energía están actualmente habilitadas, o si están deshabilitadas, las características que son compatibles. Consulte la matriz PowerManagementCapabilities para obtener esta información. Si este booleano es falso, el valor entero 1, para la cadena, ""No compatible"", debe ser la única entrada en la matriz PowerManagementCapabilities.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool PowerManagementSupported {
            get {
                if ((curObj["PowerManagementSupported"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["PowerManagementSupported"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The PrinterPaperNames property indicates the list of paper sizes supported by the" +
            " printer. The printer-specified names are used to represent supported paper size" +
            "s.\nExample: B5 (JIS).")]
        public string[] PrinterPaperNames {
            get {
                return ((string[])(curObj["PrinterPaperNames"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPrinterStateNull {
            get {
                if ((curObj["PrinterState"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"This property has been deprecated in favor of PrinterStatus, DetectedErrorState and ErrorInformation CIM properties that more clearly indicate the state and error status of the printer. The PrinterState property specifies a values indicating one of the possible states relating to this printer.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public PrinterStateValues PrinterState {
            get {
                if ((curObj["PrinterState"] == null)) {
                    return ((PrinterStateValues)(System.Convert.ToInt32(25)));
                }
                return ((PrinterStateValues)(System.Convert.ToInt32(curObj["PrinterState"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPrinterStatusNull {
            get {
                if ((curObj["PrinterStatus"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Información de estado de la impresora, más allá de lo especificado en la propieda" +
            "d LogicalDeviceAvailability. Los valores incluyen \"Inactivo\" (3) y una indicació" +
            "n que el dispositivo se encuentra actualmente imprimiendo (4).")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public PrinterStatusValues PrinterStatus {
            get {
                if ((curObj["PrinterStatus"] == null)) {
                    return ((PrinterStatusValues)(System.Convert.ToInt32(0)));
                }
                return ((PrinterStatusValues)(System.Convert.ToInt32(curObj["PrinterStatus"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The PrintJobDataType property indicates the default data type that will be used f" +
            "or a print job.")]
        public string PrintJobDataType {
            get {
                return ((string)(curObj["PrintJobDataType"]));
            }
            set {
                curObj["PrintJobDataType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The PrintProcessor property specifies the name of the print spooler that handles " +
            "print jobs.\nExample: SPOOLSS.DLL.")]
        public string PrintProcessor {
            get {
                return ((string)(curObj["PrintProcessor"]));
            }
            set {
                curObj["PrintProcessor"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPriorityNull {
            get {
                if ((curObj["Priority"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Priority property specifies the priority of the  printer. The jobs on a highe" +
            "r priority printer are scheduled first.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint Priority {
            get {
                if ((curObj["Priority"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["Priority"]));
            }
            set {
                curObj["Priority"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPublishedNull {
            get {
                if ((curObj["Published"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Published property indicates whether the printer is published in the network " +
            "directory service.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Published {
            get {
                if ((curObj["Published"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Published"]));
            }
            set {
                curObj["Published"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsQueuedNull {
            get {
                if ((curObj["Queued"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Queued property indicates whether the printer buffers and queues print jobs.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Queued {
            get {
                if ((curObj["Queued"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Queued"]));
            }
            set {
                curObj["Queued"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRawOnlyNull {
            get {
                if ((curObj["RawOnly"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The RawOnly property indicates whether the printer accepts only raw data to be sp" +
            "ooled.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool RawOnly {
            get {
                if ((curObj["RawOnly"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["RawOnly"]));
            }
            set {
                curObj["RawOnly"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The SeparatorFile property specifies the name of the file used to create a separa" +
            "tor page. This page is used to separate print jobs sent to the printer.")]
        public string SeparatorFile {
            get {
                return ((string)(curObj["SeparatorFile"]));
            }
            set {
                curObj["SeparatorFile"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The ServerName property identifies the server that controls the printer. If this " +
            "string is NULL, the printer is controlled locally. ")]
        public string ServerName {
            get {
                return ((string)(curObj["ServerName"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSharedNull {
            get {
                if ((curObj["Shared"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Shared property indicates whether the printer is available as a shared networ" +
            "k resource.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Shared {
            get {
                if ((curObj["Shared"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Shared"]));
            }
            set {
                curObj["Shared"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The ShareName property indicates the share name of the Win32 printing device.\nExa" +
            "mple: \\\\PRINTSERVER1\\PRINTER2")]
        public string ShareName {
            get {
                return ((string)(curObj["ShareName"]));
            }
            set {
                curObj["ShareName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSpoolEnabledNull {
            get {
                if ((curObj["SpoolEnabled"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The SpoolEnabled property shows whether spooling is enabled for this printer. \nVa" +
            "lues:TRUE or FALSE. \nThe SpoolEnabled property has been deprecated.  There is no" +
            " replacementvalue and this property is now considered obsolete.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool SpoolEnabled {
            get {
                if ((curObj["SpoolEnabled"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["SpoolEnabled"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsStartTimeNull {
            get {
                if ((curObj["StartTime"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The StartTime property specifies the earliest time the printer can print a job (i" +
            "f the printer has been limited to print only at certain times). This value is ex" +
            "pressed as time elapsed since 12:00 AM GMT (Greenwich mean time).")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime StartTime {
            get {
                if ((curObj["StartTime"] != null)) {
                    return ToDateTime(((string)(curObj["StartTime"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
            set {
                curObj["StartTime"] = ToDmtfDateTime(((System.DateTime)(value)));
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Status {
            get {
                return ((string)(curObj["Status"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsStatusInfoNull {
            get {
                if ((curObj["StatusInfo"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"StatusInfo es una cadena que indica si el dispositivo lógico está en un estado habilitado (valor = 3), deshabilitado (valor = 4) o algún otro estado (1) o un estado desconocido (2). Si esta propiedad no se aplica al dispositivo lógico, el valor, 5 (""No aplicable""), debe ser usado.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public StatusInfoValues StatusInfo {
            get {
                if ((curObj["StatusInfo"] == null)) {
                    return ((StatusInfoValues)(System.Convert.ToInt32(0)));
                }
                return ((StatusInfoValues)(System.Convert.ToInt32(curObj["StatusInfo"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("CreationClassName de ámbito del sistema.")]
        public string SystemCreationClassName {
            get {
                return ((string)(curObj["SystemCreationClassName"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Nombre del sistema de ámbito.")]
        public string SystemName {
            get {
                return ((string)(curObj["SystemName"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTimeOfLastResetNull {
            get {
                if ((curObj["TimeOfLastReset"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Hora de último reinicio del dispositivo de impresión.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime TimeOfLastReset {
            get {
                if ((curObj["TimeOfLastReset"] != null)) {
                    return ToDateTime(((string)(curObj["TimeOfLastReset"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsUntilTimeNull {
            get {
                if ((curObj["UntilTime"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The UntilTime property specifies the latest time the printer can print a job (if " +
            "the printer has been limited to print only at certain times). This value is expr" +
            "essed as time elapsed since 12:00 AM GMT (Greenwich mean time).")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime UntilTime {
            get {
                if ((curObj["UntilTime"] != null)) {
                    return ToDateTime(((string)(curObj["UntilTime"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
            set {
                curObj["UntilTime"] = ToDmtfDateTime(((System.DateTime)(value)));
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVerticalResolutionNull {
            get {
                if ((curObj["VerticalResolution"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Resolución vertical de la impresora en píxeles por pulgada.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint VerticalResolution {
            get {
                if ((curObj["VerticalResolution"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["VerticalResolution"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsWorkOfflineNull {
            get {
                if ((curObj["WorkOffline"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The WorkOffline property indicates whether to queue print jobs on the computer if" +
            " the printer is offline.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool WorkOffline {
            get {
                if ((curObj["WorkOffline"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["WorkOffline"]));
            }
            set {
                curObj["WorkOffline"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        private bool CheckIfProperClass(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions OptionsParam) {
            if (((path != null) 
                        && (string.Compare(path.ClassName, this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
                return true;
            }
            else {
                return CheckIfProperClass(new System.Management.ManagementObject(mgmtScope, path, OptionsParam));
            }
        }
        
        private bool CheckIfProperClass(System.Management.ManagementBaseObject theObj) {
            if (((theObj != null) 
                        && (string.Compare(((string)(theObj["__CLASS"])), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
                return true;
            }
            else {
                System.Array parentClasses = ((System.Array)(theObj["__DERIVATION"]));
                if ((parentClasses != null)) {
                    int count = 0;
                    for (count = 0; (count < parentClasses.Length); count = (count + 1)) {
                        if ((string.Compare(((string)(parentClasses.GetValue(count))), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0)) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        private bool ShouldSerializeAttributes() {
            if ((this.IsAttributesNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAttributes() {
            curObj["Attributes"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeAvailability() {
            if ((this.IsAvailabilityNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAveragePagesPerMinute() {
            if ((this.IsAveragePagesPerMinuteNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetComment() {
            curObj["Comment"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeConfigManagerErrorCode() {
            if ((this.IsConfigManagerErrorCodeNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeConfigManagerUserConfig() {
            if ((this.IsConfigManagerUserConfigNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeCurrentLanguage() {
            if ((this.IsCurrentLanguageNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeDefault() {
            if ((this.IsDefaultNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeDefaultCopies() {
            if ((this.IsDefaultCopiesNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeDefaultLanguage() {
            if ((this.IsDefaultLanguageNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeDefaultNumberUp() {
            if ((this.IsDefaultNumberUpNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeDefaultPriority() {
            if ((this.IsDefaultPriorityNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetDefaultPriority() {
            curObj["DefaultPriority"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeDetectedErrorState() {
            if ((this.IsDetectedErrorStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeDirect() {
            if ((this.IsDirectNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetDirect() {
            curObj["Direct"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeDoCompleteFirst() {
            if ((this.IsDoCompleteFirstNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetDoCompleteFirst() {
            curObj["DoCompleteFirst"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetDriverName() {
            curObj["DriverName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeEnableBIDI() {
            if ((this.IsEnableBIDINull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetEnableBIDI() {
            curObj["EnableBIDI"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeEnableDevQueryPrint() {
            if ((this.IsEnableDevQueryPrintNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetEnableDevQueryPrint() {
            curObj["EnableDevQueryPrint"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeErrorCleared() {
            if ((this.IsErrorClearedNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetErrorInformation() {
            curObj["ErrorInformation"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeExtendedDetectedErrorState() {
            if ((this.IsExtendedDetectedErrorStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeExtendedPrinterStatus() {
            if ((this.IsExtendedPrinterStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeHidden() {
            if ((this.IsHiddenNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetHidden() {
            curObj["Hidden"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeHorizontalResolution() {
            if ((this.IsHorizontalResolutionNull == false)) {
                return true;
            }
            return false;
        }
        
        // Convierte una fecha y hora determinadas con formato DMTF en un objeto System.DateTime.
        static System.DateTime ToDateTime(string dmtfDate) {
            System.DateTime initializer = System.DateTime.MinValue;
            int year = initializer.Year;
            int month = initializer.Month;
            int day = initializer.Day;
            int hour = initializer.Hour;
            int minute = initializer.Minute;
            int second = initializer.Second;
            long ticks = 0;
            string dmtf = dmtfDate;
            System.DateTime datetime = System.DateTime.MinValue;
            string tempString = string.Empty;
            if ((dmtf == null)) {
                throw new System.ArgumentOutOfRangeException();
            }
            if ((dmtf.Length == 0)) {
                throw new System.ArgumentOutOfRangeException();
            }
            if ((dmtf.Length != 25)) {
                throw new System.ArgumentOutOfRangeException();
            }
            try {
                tempString = dmtf.Substring(0, 4);
                if (("****" != tempString)) {
                    year = int.Parse(tempString);
                }
                tempString = dmtf.Substring(4, 2);
                if (("**" != tempString)) {
                    month = int.Parse(tempString);
                }
                tempString = dmtf.Substring(6, 2);
                if (("**" != tempString)) {
                    day = int.Parse(tempString);
                }
                tempString = dmtf.Substring(8, 2);
                if (("**" != tempString)) {
                    hour = int.Parse(tempString);
                }
                tempString = dmtf.Substring(10, 2);
                if (("**" != tempString)) {
                    minute = int.Parse(tempString);
                }
                tempString = dmtf.Substring(12, 2);
                if (("**" != tempString)) {
                    second = int.Parse(tempString);
                }
                tempString = dmtf.Substring(15, 6);
                if (("******" != tempString)) {
                    ticks = (long.Parse(tempString) * ((long)((System.TimeSpan.TicksPerMillisecond / 1000))));
                }
                if (((((((((year < 0) 
                            || (month < 0)) 
                            || (day < 0)) 
                            || (hour < 0)) 
                            || (minute < 0)) 
                            || (minute < 0)) 
                            || (second < 0)) 
                            || (ticks < 0))) {
                    throw new System.ArgumentOutOfRangeException();
                }
            }
            catch (System.Exception e) {
                throw new System.ArgumentOutOfRangeException(null, e.Message);
            }
            datetime = new System.DateTime(year, month, day, hour, minute, second, 0);
            datetime = datetime.AddTicks(ticks);
            System.TimeSpan tickOffset = System.TimeZone.CurrentTimeZone.GetUtcOffset(datetime);
            int UTCOffset = 0;
            int OffsetToBeAdjusted = 0;
            long OffsetMins = ((long)((tickOffset.Ticks / System.TimeSpan.TicksPerMinute)));
            tempString = dmtf.Substring(22, 3);
            if ((tempString != "******")) {
                tempString = dmtf.Substring(21, 4);
                try {
                    UTCOffset = int.Parse(tempString);
                }
                catch (System.Exception e) {
                    throw new System.ArgumentOutOfRangeException(null, e.Message);
                }
                OffsetToBeAdjusted = ((int)((OffsetMins - UTCOffset)));
                datetime = datetime.AddMinutes(((double)(OffsetToBeAdjusted)));
            }
            return datetime;
        }
        
        // Convierte un objeto System.DateTime determinado al formato de fecha y hora DMTF.
        static string ToDmtfDateTime(System.DateTime date) {
            string utcString = string.Empty;
            System.TimeSpan tickOffset = System.TimeZone.CurrentTimeZone.GetUtcOffset(date);
            long OffsetMins = ((long)((tickOffset.Ticks / System.TimeSpan.TicksPerMinute)));
            if ((System.Math.Abs(OffsetMins) > 999)) {
                date = date.ToUniversalTime();
                utcString = "+000";
            }
            else {
                if ((tickOffset.Ticks >= 0)) {
                    utcString = string.Concat("+", ((long)((tickOffset.Ticks / System.TimeSpan.TicksPerMinute))).ToString().PadLeft(3, '0'));
                }
                else {
                    string strTemp = ((long)(OffsetMins)).ToString();
                    utcString = string.Concat("-", strTemp.Substring(1, (strTemp.Length - 1)).PadLeft(3, '0'));
                }
            }
            string dmtfDateTime = ((int)(date.Year)).ToString().PadLeft(4, '0');
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Month)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Day)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Hour)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Minute)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Second)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ".");
            System.DateTime dtTemp = new System.DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, 0);
            long microsec = ((long)((((date.Ticks - dtTemp.Ticks) 
                        * 1000) 
                        / System.TimeSpan.TicksPerMillisecond)));
            string strMicrosec = ((long)(microsec)).ToString();
            if ((strMicrosec.Length > 6)) {
                strMicrosec = strMicrosec.Substring(0, 6);
            }
            dmtfDateTime = string.Concat(dmtfDateTime, strMicrosec.PadLeft(6, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, utcString);
            return dmtfDateTime;
        }
        
        private bool ShouldSerializeInstallDate() {
            if ((this.IsInstallDateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeJobCountSinceLastReset() {
            if ((this.IsJobCountSinceLastResetNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeKeepPrintedJobs() {
            if ((this.IsKeepPrintedJobsNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetKeepPrintedJobs() {
            curObj["KeepPrintedJobs"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeLastErrorCode() {
            if ((this.IsLastErrorCodeNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeLocal() {
            if ((this.IsLocalNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetLocal() {
            curObj["Local"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetLocation() {
            curObj["Location"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeMarkingTechnology() {
            if ((this.IsMarkingTechnologyNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeMaxCopies() {
            if ((this.IsMaxCopiesNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeMaxNumberUp() {
            if ((this.IsMaxNumberUpNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeMaxSizeSupported() {
            if ((this.IsMaxSizeSupportedNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeNetwork() {
            if ((this.IsNetworkNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetNetwork() {
            curObj["Network"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetParameters() {
            curObj["Parameters"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetPortName() {
            curObj["PortName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePowerManagementSupported() {
            if ((this.IsPowerManagementSupportedNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializePrinterState() {
            if ((this.IsPrinterStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializePrinterStatus() {
            if ((this.IsPrinterStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPrintJobDataType() {
            curObj["PrintJobDataType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetPrintProcessor() {
            curObj["PrintProcessor"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePriority() {
            if ((this.IsPriorityNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPriority() {
            curObj["Priority"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePublished() {
            if ((this.IsPublishedNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPublished() {
            curObj["Published"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeQueued() {
            if ((this.IsQueuedNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetQueued() {
            curObj["Queued"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeRawOnly() {
            if ((this.IsRawOnlyNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetRawOnly() {
            curObj["RawOnly"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetSeparatorFile() {
            curObj["SeparatorFile"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeShared() {
            if ((this.IsSharedNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetShared() {
            curObj["Shared"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetShareName() {
            curObj["ShareName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeSpoolEnabled() {
            if ((this.IsSpoolEnabledNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeStartTime() {
            if ((this.IsStartTimeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetStartTime() {
            curObj["StartTime"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeStatusInfo() {
            if ((this.IsStatusInfoNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeTimeOfLastReset() {
            if ((this.IsTimeOfLastResetNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeUntilTime() {
            if ((this.IsUntilTimeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetUntilTime() {
            curObj["UntilTime"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVerticalResolution() {
            if ((this.IsVerticalResolutionNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeWorkOffline() {
            if ((this.IsWorkOfflineNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetWorkOffline() {
            curObj["WorkOffline"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        [Browsable(true)]
        public void CommitObject() {
            if ((isEmbedded == false)) {
                PrivateLateBoundObject.Put();
            }
        }
        
        [Browsable(true)]
        public void CommitObject(System.Management.PutOptions putOptions) {
            if ((isEmbedded == false)) {
                PrivateLateBoundObject.Put(putOptions);
            }
        }
        
        private void Initialize() {
            AutoCommitProp = true;
            isEmbedded = false;
        }
        
        private static string ConstructPath(string keyDeviceID) {
            string strPath = "ROOT\\CIMV2:Win32_Printer";
            strPath = string.Concat(strPath, string.Concat(".DeviceID=", string.Concat("\"", string.Concat(keyDeviceID, "\""))));
            return strPath;
        }
        
        private void InitializeObject(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            Initialize();
            if ((path != null)) {
                if ((CheckIfProperClass(mgmtScope, path, getOptions) != true)) {
                    throw new System.ArgumentException("El nombre de clase no coincide.");
                }
            }
            PrivateLateBoundObject = new System.Management.ManagementObject(mgmtScope, path, getOptions);
            PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
            curObj = PrivateLateBoundObject;
        }
        
        // Diferentes sobrecargas de ayuda GetInstances() para enumerar instancias de la clase WMI.
        public static PrinterCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static PrinterCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static PrinterCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static PrinterCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static PrinterCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\CIMV2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementPath pathObj = new System.Management.ManagementPath();
            pathObj.ClassName = "Win32_Printer";
            pathObj.NamespacePath = "root\\CIMV2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new PrinterCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static PrinterCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static PrinterCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static PrinterCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\CIMV2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("Win32_Printer", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new PrinterCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static Printer CreateInstance() {
            System.Management.ManagementScope mgmtScope = null;
            if ((statMgmtScope == null)) {
                mgmtScope = new System.Management.ManagementScope();
                mgmtScope.Path.NamespacePath = CreatedWmiNamespace;
            }
            else {
                mgmtScope = statMgmtScope;
            }
            System.Management.ManagementPath mgmtPath = new System.Management.ManagementPath(CreatedClassName);
            System.Management.ManagementClass tmpMgmtClass = new System.Management.ManagementClass(mgmtScope, mgmtPath, null);
            return new Printer(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        public static uint AddPrinterConnection(string Name) {
            bool IsMethodStatic = true;
            if ((IsMethodStatic == true)) {
                System.Management.ManagementBaseObject inParams = null;
                System.Management.ManagementPath mgmtPath = new System.Management.ManagementPath(CreatedClassName);
                System.Management.ManagementClass classObj = new System.Management.ManagementClass(statMgmtScope, mgmtPath, null);
                inParams = classObj.GetMethodParameters("AddPrinterConnection");
                inParams["Name"] = ((string)(Name));
                System.Management.ManagementBaseObject outParams = classObj.InvokeMethod("AddPrinterConnection", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint CancelAllJobs() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("CancelAllJobs", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint GetSecurityDescriptor(out System.Management.ManagementBaseObject Descriptor) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("GetSecurityDescriptor", inParams, null);
                Descriptor = ((System.Management.ManagementBaseObject)(outParams.Properties["Descriptor"].Value));
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                Descriptor = null;
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint Pause() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("Pause", inParams, null);
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint PrintTestPage() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("PrintTestPage", inParams, null);
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint RenamePrinter(string NewPrinterName) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                inParams = PrivateLateBoundObject.GetMethodParameters("RenamePrinter");
                inParams["NewPrinterName"] = ((string)(NewPrinterName));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("RenamePrinter", inParams, null);
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint Reset() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("Reset", inParams, null);
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint Resume() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("Resume", inParams, null);
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint SetDefaultPrinter() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetDefaultPrinter", inParams, null);
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint SetPowerState(ushort PowerState, System.DateTime Time) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetPowerState");
                inParams["PowerState"] = ((ushort)(PowerState));
                inParams["Time"] = ToDmtfDateTime(((System.DateTime)(Time)));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetPowerState", inParams, null);
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint SetSecurityDescriptor(System.Management.ManagementBaseObject Descriptor) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                bool EnablePrivileges = PrivateLateBoundObject.Scope.Options.EnablePrivileges;
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetSecurityDescriptor");
                inParams["Descriptor"] = ((System.Management.ManagementBaseObject )(Descriptor));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetSecurityDescriptor", inParams, null);
                PrivateLateBoundObject.Scope.Options.EnablePrivileges = EnablePrivileges;
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public enum AttributesValues {
            
            Queued0 = 1,
            
            Direct0 = 2,
            
            Default0 = 4,
            
            Shared0 = 8,
            
            Network0 = 16,
            
            Hidden0 = 32,
            
            Local0 = 64,
            
            EnableDevQ = 128,
            
            KeepPrintedJobs0 = 256,
            
            DoCompleteFirst0 = 512,
            
            WorkOffline0 = 1024,
            
            EnableBIDI0 = 2048,
            
            RawOnly0 = 4096,
            
            Published0 = 8192,
            
            NULL_ENUM_VALUE = 16384,
        }
        
        public enum AvailabilityValues {
            
            Otros = 1,
            
            Desconocido = 2,
            
            Funcionar_Energía_completa = 3,
            
            Advertencia = 4,
            
            En_prueba = 5,
            
            No_aplicable = 6,
            
            Apagado = 7,
            
            Sin_conexión_a_la_red = 8,
            
            Inactivo = 9,
            
            Degradado = 10,
            
            No_instalado = 11,
            
            Error_de_instalación = 12,
            
            Ahorro_de_energía_desconocido = 13,
            
            Ahorro_de_energía_modo_de_bajo_consumo = 14,
            
            Ahorro_de_energía_espera = 15,
            
            Ciclo_de_energía = 16,
            
            Ahorro_de_energía_advertencia = 17,
            
            Pausado = 18,
            
            No_está_listo = 19,
            
            No_configurado = 20,
            
            Inactivo0 = 21,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum CapabilitiesValues {
            
            Desconocido = 0,
            
            Otros = 1,
            
            Impresión_en_color = 2,
            
            Impresión_a_doble_cara = 3,
            
            Copias = 4,
            
            Intercalación = 5,
            
            Engrapado = 6,
            
            Impresión_de_transparencia = 7,
            
            Perforación = 8,
            
            Portada = 9,
            
            Enlazar = 10,
            
            Impresión_en_blanco_y_negro = 11,
            
            A_una_cara = 12,
            
            Borde_largo_a_doble_cara = 13,
            
            Borde_corto_a_doble_cara = 14,
            
            Vertical = 15,
            
            Horizontal = 16,
            
            Vertical_invertido = 17,
            
            Horizontal_invertido = 18,
            
            Calidad_alta = 19,
            
            Calidad_normal = 20,
            
            Calidad_baja = 21,
            
            NULL_ENUM_VALUE = 22,
        }
        
        public enum ConfigManagerErrorCodeValues {
            
            Este_dispositivo_funciona_correctamente_ = 0,
            
            El_dispositivo_no_está_configurado_correctamente_ = 1,
            
            Windows_no_puede_cargar_el_controlador_para_este_dispositivo_ = 2,
            
            El_controlador_de_este_dispositivo_podría_estar_dañado_o_es_posible_que_su_sistema_tenga_poca_memoria_u_otros_recursos_ = 3,
            
            Este_dispositivo_no_funciona_correctamente_Podría_estar_dañado_uno_de_sus_controladores_o_el_Registro_ = 4,
            
            El_controlador_de_este_dispositivo_necesita_un_recurso_que_Windows_no_puede_administrar_ = 5,
            
            La_configuración_de_arranque_de_este_dispositivo_está_en_conflicto_con_otros_dispositivos_ = 6,
            
            No_se_puede_filtrar_ = 7,
            
            Falta_el_controlador_del_dispositivo_ = 8,
            
            Este_dispositivo_no_funciona_correctamente_porque_el_firmware_de_control_informa_incorrectamente_de_los_recursos_del_dispositivo_ = 9,
            
            No_puede_iniciar_este_dispositivo_ = 10,
            
            Error_de_este_dispositivo_ = 11,
            
            Este_dispositivo_no_encuentra_suficientes_recursos_libres_que_pueda_usar_ = 12,
            
            Windows_no_puede_comprobar_los_recursos_de_este_dispositivo_ = 13,
            
            El_dispositivo_no_puede_funcionar_correctamente_hasta_que_reinicie_su_equipo_ = 14,
            
            Este_dispositivo_no_funciona_correctamente_porque_quizá_existe_un_problema_de_reenumeración_ = 15,
            
            Windows_no_puede_identificar_todos_los_recursos_que_usa_este_dispositivo_ = 16,
            
            Este_dispositivo_está_solicitando_un_tipo_de_recurso_desconocido_ = 17,
            
            Reinstalar_los_controladores_de_este_dispositivo_ = 18,
            
            Error_al_usar_el_cargador_VxD_ = 19,
            
            Su_Registro_podría_estar_dañado_ = 20,
            
            Error_del_sistema_pruebe_a_cambiar_el_controlador_de_este_dispositivo_Si_eso_no_funciona_consulte_la_documentación_del_hardware_Windows_quitará_este_dispositivo_ = 21,
            
            Este_dispositivo_está_deshabilitado_ = 22,
            
            Error_del_sistema_pruebe_a_cambiar_el_controlador_de_este_dispositivo_Si_eso_no_funciona_consulte_la_documentación_del_hardware_ = 23,
            
            Este_dispositivo_no_está_presente_no_funciona_correctamente_o_no_tiene_todos_sus_controladores_instalados_ = 24,
            
            Windows_sigue_configurando_este_dispositivo_ = 25,
            
            Windows_sigue_configurando_este_dispositivo_0 = 26,
            
            Este_dispositivo_no_tiene_una_configuración_de_registro_válida_ = 27,
            
            Los_controladores_de_este_dispositivo_no_están_instalados_ = 28,
            
            Este_dispositivo_está_deshabilitado_porque_su_firmware_no_le_proporcionó_los_recursos_requeridos_ = 29,
            
            Este_dispositivo_usa_un_recurso_de_solicitud_de_interrupción_IRQ_que_usa_otro_dispositivo_ = 30,
            
            Este_dispositivo_no_funciona_correctamente_porque_Windows_no_puede_cargar_los_controladores_requeridos_para_este_dispositivo_ = 31,
            
            NULL_ENUM_VALUE = 32,
        }
        
        public enum CurrentCapabilitiesValues {
            
            Desconocido = 0,
            
            Otros = 1,
            
            Impresión_en_color = 2,
            
            Impresión_a_doble_cara = 3,
            
            Copias = 4,
            
            Intercalación = 5,
            
            Engrapado = 6,
            
            Impresión_de_transparencia = 7,
            
            Perforación = 8,
            
            Portada = 9,
            
            Enlazar = 10,
            
            Impresión_en_blanco_y_negro = 11,
            
            A_una_cara = 12,
            
            Borde_largo_a_doble_cara = 13,
            
            Borde_corto_a_doble_cara = 14,
            
            Vertical = 15,
            
            Horizontal = 16,
            
            Vertical_invertido = 17,
            
            Horizontal_invertido = 18,
            
            Calidad_alta = 19,
            
            Calidad_normal = 20,
            
            Calidad_baja = 21,
            
            NULL_ENUM_VALUE = 22,
        }
        
        public enum CurrentLanguageValues {
            
            Otros = 1,
            
            Desconocido = 2,
            
            PCL = 3,
            
            HPGL = 4,
            
            PJL = 5,
            
            PS = 6,
            
            PSPrinter = 7,
            
            IPDS = 8,
            
            PPDS = 9,
            
            EscapeP = 10,
            
            EPSON = 11,
            
            DDIF = 12,
            
            Interpress = 13,
            
            ISO6429 = 14,
            
            Datos_de_línea = 15,
            
            MODCA = 16,
            
            REGIS = 17,
            
            SCS = 18,
            
            SPDL = 19,
            
            TEK4014 = 20,
            
            PDS = 21,
            
            IGP = 22,
            
            CodeV = 23,
            
            DSCDSE = 24,
            
            WPS = 25,
            
            LN03 = 26,
            
            CCITT = 27,
            
            QUIC = 28,
            
            CPAP = 29,
            
            DecPPL = 30,
            
            Texto_simple = 31,
            
            NPAP = 32,
            
            DOC = 33,
            
            ImPress = 34,
            
            Pinwriter = 35,
            
            NPDL = 36,
            
            NEC201PL = 37,
            
            Automático = 38,
            
            Páginas = 39,
            
            LIPS = 40,
            
            TIFF = 41,
            
            Diagnóstico = 42,
            
            CaPSL = 43,
            
            EXCL = 44,
            
            LCDS = 45,
            
            XES = 46,
            
            MIME = 47,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum DefaultCapabilitiesValues {
            
            Desconocido = 0,
            
            Otros = 1,
            
            Impresión_en_color = 2,
            
            Impresión_a_doble_cara = 3,
            
            Copias = 4,
            
            Intercalación = 5,
            
            Engrapado = 6,
            
            Impresión_de_transparencia = 7,
            
            Perforación = 8,
            
            Portada = 9,
            
            Enlazar = 10,
            
            Impresión_en_blanco_y_negro = 11,
            
            A_una_cara = 12,
            
            Borde_largo_a_doble_cara = 13,
            
            Borde_corto_a_doble_cara = 14,
            
            Vertical = 15,
            
            Horizontal = 16,
            
            Vertical_invertido = 17,
            
            Horizontal_invertido = 18,
            
            Calidad_alta = 19,
            
            Calidad_normal = 20,
            
            Calidad_baja = 21,
            
            NULL_ENUM_VALUE = 22,
        }
        
        public enum DefaultLanguageValues {
            
            Otros = 1,
            
            Desconocido = 2,
            
            PCL = 3,
            
            HPGL = 4,
            
            PJL = 5,
            
            PS = 6,
            
            PSPrinter = 7,
            
            IPDS = 8,
            
            PPDS = 9,
            
            EscapeP = 10,
            
            EPSON = 11,
            
            DDIF = 12,
            
            Interpress = 13,
            
            ISO6429 = 14,
            
            Datos_de_línea = 15,
            
            MODCA = 16,
            
            REGIS = 17,
            
            SCS = 18,
            
            SPDL = 19,
            
            TEK4014 = 20,
            
            PDS = 21,
            
            IGP = 22,
            
            CodeV = 23,
            
            DSCDSE = 24,
            
            WPS = 25,
            
            LN03 = 26,
            
            CCITT = 27,
            
            QUIC = 28,
            
            CPAP = 29,
            
            DecPPL = 30,
            
            Texto_simple = 31,
            
            NPAP = 32,
            
            DOC = 33,
            
            ImPress = 34,
            
            Pinwriter = 35,
            
            NPDL = 36,
            
            NEC201PL = 37,
            
            Automático = 38,
            
            Páginas = 39,
            
            LIPS = 40,
            
            TIFF = 41,
            
            Diagnóstico = 42,
            
            CaPSL = 43,
            
            EXCL = 44,
            
            LCDS = 45,
            
            XES = 46,
            
            MIME = 47,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum DetectedErrorStateValues {
            
            Desconocido = 0,
            
            Otros = 1,
            
            Sin_errores = 2,
            
            Falta_papel = 3,
            
            No_hay_papel = 4,
            
            Falta_tóner = 5,
            
            No_hay_tóner = 6,
            
            La_puerta_está_abierta = 7,
            
            Papel_atascado = 8,
            
            Sin_conexión = 9,
            
            Servicio_solicitado = 10,
            
            Bandeja_de_salida_llena = 11,
            
            NULL_ENUM_VALUE = 12,
        }
        
        public enum ExtendedDetectedErrorStateValues {
            
            Unknown0 = 0,
            
            Other0 = 1,
            
            No_Error = 2,
            
            Low_Paper = 3,
            
            No_Paper = 4,
            
            Low_Toner = 5,
            
            No_Toner = 6,
            
            Door_Open = 7,
            
            Jammed = 8,
            
            Service_Requested = 9,
            
            Output_Bin_Full = 10,
            
            Paper_Problem = 11,
            
            Cannot_Print_Page = 12,
            
            User_Intervention_Required = 13,
            
            Out_of_Memory = 14,
            
            Server_Unknown = 15,
            
            NULL_ENUM_VALUE = 16,
        }
        
        public enum ExtendedPrinterStatusValues {
            
            Other0 = 1,
            
            Unknown0 = 2,
            
            Idle = 3,
            
            Printing = 4,
            
            Warmup = 5,
            
            Stopped_Printing = 6,
            
            Offline = 7,
            
            Paused = 8,
            
            Error = 9,
            
            Busy = 10,
            
            Not_Available = 11,
            
            Waiting = 12,
            
            Processing = 13,
            
            Initialization = 14,
            
            Power_Save = 15,
            
            Pending_Deletion = 16,
            
            I_O_Active = 17,
            
            Manual_Feed = 18,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum LanguagesSupportedValues {
            
            Otros = 1,
            
            Desconocido = 2,
            
            PCL = 3,
            
            HPGL = 4,
            
            PJL = 5,
            
            PS = 6,
            
            PSPrinter = 7,
            
            IPDS = 8,
            
            PPDS = 9,
            
            EscapeP = 10,
            
            EPSON = 11,
            
            DDIF = 12,
            
            Interpress = 13,
            
            ISO6429 = 14,
            
            Datos_de_línea = 15,
            
            MODCA = 16,
            
            REGIS = 17,
            
            SCS = 18,
            
            SPDL = 19,
            
            TEK4014 = 20,
            
            PDS = 21,
            
            IGP = 22,
            
            CodeV = 23,
            
            DSCDSE = 24,
            
            WPS = 25,
            
            LN03 = 26,
            
            CCITT = 27,
            
            QUIC = 28,
            
            CPAP = 29,
            
            DecPPL = 30,
            
            Texto_simple = 31,
            
            NPAP = 32,
            
            DOC = 33,
            
            ImPress = 34,
            
            Pinwriter = 35,
            
            NPDL = 36,
            
            NEC201PL = 37,
            
            Automático = 38,
            
            Páginas = 39,
            
            LIPS = 40,
            
            TIFF = 41,
            
            Diagnóstico = 42,
            
            CaPSL = 43,
            
            EXCL = 44,
            
            LCDS = 45,
            
            XES = 46,
            
            MIME = 47,
            
            XPS = 48,
            
            HPGL2 = 49,
            
            PCLXL = 50,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum MarkingTechnologyValues {
            
            Otros = 1,
            
            Desconocido = 2,
            
            LED_electrográfico = 3,
            
            Láser_electrográfico = 4,
            
            Otro_dispositivo_electrográfico = 5,
            
            Matriz_de_puntos_de_cabezal_movible_de_impacto_de_9_clavijas = 6,
            
            Matriz_de_puntos_de_cabezal_movible_de_impacto_de_24_clavijas = 7,
            
            Otras_de_matriz_de_puntos_de_cabezal_movible_de_impacto = 8,
            
            Cabezal_movible_de_impacto_totalmente_formado = 9,
            
            Banda_de_impacto = 10,
            
            Otras_de_impacto = 11,
            
            Inyección_acuosa = 12,
            
            Inyección_sólida = 13,
            
            Otras_de_inyección = 14,
            
            Plumilla = 15,
            
            Transferencia_térmica = 16,
            
            Sensibilidad_térmica = 17,
            
            Difusión_térmica = 18,
            
            Otras_métodos_térmicos = 19,
            
            Electroerosión = 20,
            
            Electrostática = 21,
            
            Microficha_fotográfica = 22,
            
            Máquina_fotográfica_de_composición_de_imágenes = 23,
            
            Otros_dispositivos_fotográficos = 24,
            
            Sedimentación_de_iones = 25,
            
            Haz_de_electrones_eBeam_ = 26,
            
            Máquina_tipográfica = 27,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum PaperSizesSupportedValues {
            
            Desconocido = 0,
            
            Otros = 1,
            
            A = 2,
            
            B = 3,
            
            C = 4,
            
            D = 5,
            
            E = 6,
            
            Carta = 7,
            
            Oficio = 8,
            
            Sobre_NA_10x13 = 9,
            
            Sobre_NA_9x12 = 10,
            
            Sobre_NA_Número_10 = 11,
            
            Sobre_NA_7x9 = 12,
            
            Sobre_NA_9x11 = 13,
            
            Sobre_NA_10x14 = 14,
            
            Sobre_NA_Número_9 = 15,
            
            Sobre_NA_6x9 = 16,
            
            Sobre_NA_10x15 = 17,
            
            A0 = 18,
            
            A1 = 19,
            
            A2 = 20,
            
            A3 = 21,
            
            A4 = 22,
            
            A5 = 23,
            
            A6 = 24,
            
            A7 = 25,
            
            A8 = 26,
            
            A9A10 = 27,
            
            B0 = 28,
            
            B1 = 29,
            
            B2 = 30,
            
            B3 = 31,
            
            B4 = 32,
            
            B5 = 33,
            
            B6 = 34,
            
            B7 = 35,
            
            B8 = 36,
            
            B9 = 37,
            
            B10 = 38,
            
            C0 = 39,
            
            C1 = 40,
            
            C2C3 = 41,
            
            C4 = 42,
            
            C5 = 43,
            
            C6 = 44,
            
            C7 = 45,
            
            C8 = 46,
            
            Designado_por_ISO = 47,
            
            JIS_B0 = 48,
            
            JIS_B1 = 49,
            
            JIS_B2 = 50,
            
            JIS_B3 = 51,
            
            JIS_B4 = 52,
            
            JIS_B5 = 53,
            
            JIS_B6 = 54,
            
            JIS_B7 = 55,
            
            JIS_B8 = 56,
            
            JIS_B9 = 57,
            
            JIS_B10 = 58,
            
            Carta_NA = 59,
            
            Oficio_NA = 60,
            
            Sobre_C4 = 61,
            
            Sobre_B4 = 62,
            
            Sobre_C3 = 63,
            
            Sobre_C40 = 64,
            
            Sobre_C5 = 65,
            
            Sobre_C6 = 66,
            
            Sobre_largo_designado = 67,
            
            Sobre_Monarca = 68,
            
            Ejecutivo = 69,
            
            Folio = 70,
            
            Factura = 71,
            
            Doble_carta = 72,
            
            Cuarto = 73,
            
            NULL_ENUM_VALUE = 74,
        }
        
        public enum PowerManagementCapabilitiesValues {
            
            Desconocido = 0,
            
            No_compatible = 1,
            
            Deshabilitado = 2,
            
            Habilitado = 3,
            
            Modos_de_ahorro_de_energía_establecidos_automáticamente = 4,
            
            Estado_de_energía_configurable = 5,
            
            Ciclo_de_energía_permitido = 6,
            
            Se_admite_el_encendido_por_tiempo = 7,
            
            NULL_ENUM_VALUE = 8,
        }
        
        public enum PrinterStateValues {
            
            Paused = 0,
            
            Error = 1,
            
            Pending_Deletion = 2,
            
            Paper_Jam = 3,
            
            Paper_Out = 4,
            
            Manual_Feed = 5,
            
            Paper_Problem = 6,
            
            Offline = 7,
            
            IO_Active = 8,
            
            Busy = 9,
            
            Printing = 10,
            
            Output_Bin_Full = 11,
            
            Not_Available = 12,
            
            Waiting = 13,
            
            Processing = 14,
            
            Initialization = 15,
            
            Warming_Up = 16,
            
            Toner_Low = 17,
            
            No_Toner = 18,
            
            Page_Punt = 19,
            
            User_Intervention_Required = 20,
            
            Out_of_Memory = 21,
            
            Door_Open = 22,
            
            Server_Unknown = 23,
            
            Power_Save = 24,
            
            NULL_ENUM_VALUE = 25,
        }
        
        public enum PrinterStatusValues {
            
            Otros = 1,
            
            Desconocido = 2,
            
            Inactivo = 3,
            
            Imprimiendo = 4,
            
            Calentamiento = 5,
            
            Impresión_detenida = 6,
            
            Sin_conexión = 7,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum StatusInfoValues {
            
            Otros = 1,
            
            Desconocido = 2,
            
            Habilitado = 3,
            
            Deshabilitado = 4,
            
            No_aplicable = 5,
            
            NULL_ENUM_VALUE = 0,
        }
        
        // Implementación del enumerador para enumerar instancias de la clase.
        public class PrinterCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public PrinterCollection(ManagementObjectCollection objCollection) {
                privColObj = objCollection;
            }
            
            public virtual int Count {
                get {
                    return privColObj.Count;
                }
            }
            
            public virtual bool IsSynchronized {
                get {
                    return privColObj.IsSynchronized;
                }
            }
            
            public virtual object SyncRoot {
                get {
                    return this;
                }
            }
            
            public virtual void CopyTo(System.Array array, int index) {
                privColObj.CopyTo(array, index);
                int nCtr;
                for (nCtr = 0; (nCtr < array.Length); nCtr = (nCtr + 1)) {
                    array.SetValue(new Printer(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new PrinterEnumerator(privColObj.GetEnumerator());
            }
            
            public class PrinterEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public PrinterEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new Printer(((System.Management.ManagementObject)(privObjEnum.Current)));
                    }
                }
                
                public virtual bool MoveNext() {
                    return privObjEnum.MoveNext();
                }
                
                public virtual void Reset() {
                    privObjEnum.Reset();
                }
            }
        }
        
        // Elemento TypeConverter que administra valores NULL para propiedades ValueType
        public class WMIValueTypeConverter : TypeConverter {
            
            private TypeConverter baseConverter;
            
            private System.Type baseType;
            
            public WMIValueTypeConverter(System.Type inBaseType) {
                baseConverter = TypeDescriptor.GetConverter(inBaseType);
                baseType = inBaseType;
            }
            
            public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type srcType) {
                return baseConverter.CanConvertFrom(context, srcType);
            }
            
            public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) {
                return baseConverter.CanConvertTo(context, destinationType);
            }
            
            public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
                return baseConverter.ConvertFrom(context, culture, value);
            }
            
            public override object CreateInstance(System.ComponentModel.ITypeDescriptorContext context, System.Collections.IDictionary dictionary) {
                return baseConverter.CreateInstance(context, dictionary);
            }
            
            public override bool GetCreateInstanceSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetCreateInstanceSupported(context);
            }
            
            public override PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributeVar) {
                return baseConverter.GetProperties(context, value, attributeVar);
            }
            
            public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetPropertiesSupported(context);
            }
            
            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValues(context);
            }
            
            public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValuesExclusive(context);
            }
            
            public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValuesSupported(context);
            }
            
            public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) {
                if ((baseType.BaseType == typeof(System.Enum))) {
                    if ((value.GetType() == destinationType)) {
                        return value;
                    }
                    if ((((value == null) 
                                && (context != null)) 
                                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                        return  "NULL_ENUM_VALUE" ;
                    }
                    return baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if (((baseType == typeof(bool)) 
                            && (baseType.BaseType == typeof(System.ValueType)))) {
                    if ((((value == null) 
                                && (context != null)) 
                                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                        return "";
                    }
                    return baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if (((context != null) 
                            && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                    return "";
                }
                return baseConverter.ConvertTo(context, culture, value, destinationType);
            }
        }
        
        // Clase incrustada que representa las propiedades WMI del sistema.
        [TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
        public class ManagementSystemProperties {
            
            private System.Management.ManagementBaseObject PrivateLateBoundObject;
            
            public ManagementSystemProperties(System.Management.ManagementBaseObject ManagedObject) {
                PrivateLateBoundObject = ManagedObject;
            }
            
            [Browsable(true)]
            public int GENUS {
                get {
                    return ((int)(PrivateLateBoundObject["__GENUS"]));
                }
            }
            
            [Browsable(true)]
            public string CLASS {
                get {
                    return ((string)(PrivateLateBoundObject["__CLASS"]));
                }
            }
            
            [Browsable(true)]
            public string SUPERCLASS {
                get {
                    return ((string)(PrivateLateBoundObject["__SUPERCLASS"]));
                }
            }
            
            [Browsable(true)]
            public string DYNASTY {
                get {
                    return ((string)(PrivateLateBoundObject["__DYNASTY"]));
                }
            }
            
            [Browsable(true)]
            public string RELPATH {
                get {
                    return ((string)(PrivateLateBoundObject["__RELPATH"]));
                }
            }
            
            [Browsable(true)]
            public int PROPERTY_COUNT {
                get {
                    return ((int)(PrivateLateBoundObject["__PROPERTY_COUNT"]));
                }
            }
            
            [Browsable(true)]
            public string[] DERIVATION {
                get {
                    return ((string[])(PrivateLateBoundObject["__DERIVATION"]));
                }
            }
            
            [Browsable(true)]
            public string SERVER {
                get {
                    return ((string)(PrivateLateBoundObject["__SERVER"]));
                }
            }
            
            [Browsable(true)]
            public string NAMESPACE {
                get {
                    return ((string)(PrivateLateBoundObject["__NAMESPACE"]));
                }
            }
            
            [Browsable(true)]
            public string PATH {
                get {
                    return ((string)(PrivateLateBoundObject["__PATH"]));
                }
            }
        }
    }
}
