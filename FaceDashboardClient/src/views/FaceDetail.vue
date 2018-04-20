<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col md="6" sm="6" lg="6">
        <b-card no-body>
          <b-card-body>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>FaceId</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                {{face.FaceId}}
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Age</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                {{face.Age}}
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Gender</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                {{face.Gender}}
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Glasses</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                {{face.Glassess}}
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Smile</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                {{face.Smile}}
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Moustache</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                {{face.Moustache}}
              </b-col>
            </b-row>

          </b-card-body>
        </b-card>
      </b-col>
      <b-col md="6" sm="6" lg="6">
        <b-card no-body>
          <b-card-body>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Beard</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                {{face.Beard}}
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Sideburns</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                {{face.Sideburns}}
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Left</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                <span id="face-left">{{face.FaceRectangleLeft}}</span>
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Top</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                <span id="face-top">{{face.FaceRectangleTop}}</span>
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Width</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                <span id="face-width">{{face.FaceRectangleWidth}}</span>
              </b-col>
            </b-row>
            <b-row>
              <b-col md="12" sm="12" lg="12">
                <strong>Height</strong>
              </b-col>
              <b-col md="12" sm="12" lg="12">
                <span id="face-height">{{face.FaceRectangleHeight}}</span>
              </b-col>
            </b-row>
          </b-card-body>
        </b-card>
      </b-col>
    </b-row>
    <b-row>

      <div id="container" style="position: absolute; left: -10000px; top: -100000px;"></div>
      <canvas id="faceContainer"></canvas>

    </b-row>
    <b-row>
    </b-row>
  </div>
</template>
<script>
  import axios from 'axios';

  export default {
    name: 'facedetail',
    data: function () {
      return {
        imgSrc: 'https://imagesaccount.blob.core.windows.net/faces/24176012-collage-of-many-different-human-faces.jpg',
        left: 308.0000,
        top: 992.0000,
        width: 152.0000,
        height: 152.0000,
        faceId: '96BE142A-E2E7-4A6F-962F-CD146F6A3EE2',
        age: 26.10,
        gender: 'male',
        glassess: 'NoGlasses',
        smile: 1.0000,
        moustache: 0.0000,
        beard: 0.0000,
        sideburns: 0.0000,
        pitch: 0.0000,
        face: {}
      }
    },
    beforeMount() {
      //let that = this
      //let id = this.$route.query.id;
      //axios.get(`https://face-dashboard-api.azurewebsites.net/api/dashboard/faces/${id}`)
      //  .then(response => {
      //    that.face = response.data
      //    console.log(that.face);
      //  })
      //  .catch(e => {
      //    this.errors.push(e)
      //  })
    },
    mounted() {
      axios.get(`https://face-dashboard-api.azurewebsites.net/api/dashboard/faces/${this.$route.query.id}`)
        .then(response => {
          this.face = response.data;
          var img = new Image();
          var container = document.getElementById('container');
          img.src = this.face.FileUrl;
          container.appendChild(img);
          console.log(img.src);
          var top = this.face.FaceRectangleTop;
          var left = this.face.FaceRectangleLeft;
          var faceWidth = this.face.FaceRectangleWidth;
          var faceHeight = this.face.FaceRectangleHeight;
          img.onload = function () {
            var canvas = document.getElementById('faceContainer');
            canvas.width = img.width;
            canvas.height = img.height;
            var context = canvas.getContext('2d');
            context.drawImage(img, 0, 0);
            context.rect(left, top, faceWidth, faceHeight);
            context.strokeStyle = "#FF0000";
            context.stroke();
          }

          //var first = document.createElement('img');
          //first.src = this.face.FileUrl;

        });

      //var context = canvas.getContext('2d');
      //context.drawImage(first, 0, 0);
      //context.rect(617.0000, 868.0000, 783.0000, 783.0000);

      //context.strokeStyle = "#FF0000";
      //context.stroke();

      //console.log('mounted')
      //let srcImg = document.getElementById('face');
      //let canvas = document.getElementById('faceContainer');
      //canvas.width = srcImg.width;
      //canvas.height = srcImg.height;
      //var context = canvas.getContext('2d');
      //let left = parseInt(document.getElementById('face-left').innerText)
      //let top = parseInt(document.getElementById('face-top').innerText)
      //let width = parseInt(document.getElementById('face-width').innerText)
      //let height = parseInt(document.getElementById('face-height').innerText)
      //context.drawImage(srcImg, 0, 0);
      //context.rect(left, top, width, height);
      //context.strokeStyle = "#FF0000";
      //context.stroke();
    },
    computed: {
      isSmile() {
        return this.smile > 0.5 ? 'Yes' : 'No'
      }
    }
  }
</script>
