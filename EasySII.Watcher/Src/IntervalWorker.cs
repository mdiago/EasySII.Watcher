/*
    This file is part of the EasySII (R) project.
    Copyright (c) 2017-2018 Irene Solutions SL
    Authors: Irene Solutions SL.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    IRENE SOLUTIONS SL. IRENE SOLUTIONS SL DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS
    
    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
        http://www.irenesolutions.com/terms-of-use.pdf
    
    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.
    
    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the EasySII software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving sii XML data on the fly in a web application, shipping EasySII
    with a closed source product.
    
    For more information, please contact Irene Solutions SL. at this
    address: info@irenesolutions.com
 */

using System.Threading;


namespace EasySII.Watcher
{

    /// <summary>
    /// Clase para ejecutar en un hilo de fondo
    /// una tarea de manera periodica.
    /// </summary>
    public class IntervalWorker
    {

        /// <summary>
        /// Utilizado para esperar el intervalo determinado,
        /// y para finalizar definitivamente el hilo de trabajo.
        /// </summary>
        ManualResetEvent _End;

        /// <summary>
        /// Intervalo en milegundos entre cada ejecución.
        /// </summary>
        public int Interval = 3000;

        /// <summary>
        /// Proceso a ejecutar periódicamente entre
        /// intervalos.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        /// Comienza a ejecutar el proceso de manera
        /// continua y periodica hasta que se finaliza
        /// el trabajo con End.
        /// </summary>
        public void Start()
        {
            _End = new ManualResetEvent(false);
            new Thread(Process).Start();
        }


        /// <summary>
        /// Finaliza el trabajo.
        /// </summary>
        public void End()
        {
            _End.Set();
        }



        #region Métodos privados

        /// <summary>
        /// Procedimiento en bucle en el que ejecuta periódicamente
        /// el método Execute.
        /// </summary>
        private void Process()
        {
            while (true)
            {
                if (_End.WaitOne(Interval))
                    break;
                Execute();
            }
        }

        #endregion

    }

}
