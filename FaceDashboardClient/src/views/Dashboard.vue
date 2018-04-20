<template>
  <div class="animated fadeIn">
    <b-row class="mb-2">
      <b-col md="12">
        <strong>Total:{{totalFace}}</strong>
      </b-col>
    </b-row>
    <b-row>
      <b-col md="12" sm="12" lg="12">
        <b-table class="mb-0 table-outline" responsive="sm" hover :items="faces" :fields="faceFields">
          <div slot="FaceId" slot-scope="item">
            <router-link :to="{path:'detail', query:{id:item.value}}">{{item.value}}</router-link>
          </div>
        </b-table>
      </b-col>
    </b-row>
  </div>
</template>

<script>
  import $ from 'jquery'
  import 'ms-signalr-client-jquery-3'
  import axios from 'axios';

  export default {
    name: 'dashboard',
    data() {
      return {        
        faces: [],
        faceFields: {
          FaceId: {
            label: 'FaceId'
          },
          Age: {
            label: 'Age'
          },
          Gender: {
            label: 'Gender'
          },
          Smile: {
            label: 'Smile'
          },
          Moustache: {
            label: 'Moustache'
          }
        },
        connection: null,
        proxy: null
      }
    },
    beforeMount() {
      let that = this;
      this.connection = $.hubConnection('https://face-dashboard-api.azurewebsites.net/signalr')
      this.proxy = this.connection.createHubProxy('dashboard')
      this.proxy.on('updateDashboard', (name, faceDto) => {
        console.log(faceDto);
        that.faces.push(faceDto)
      })

      console.log(this.connection)
      this.connection
        .start({ withCredentials: false })
        .done(() => { console.log('Now connected, connection ID=' + that.connection.id) })
        .fail(() => { console.log('Could not connect') })

      axios.get(`https://face-dashboard-api.azurewebsites.net/api/dashboard/faces`)
        .then(response => {
          that.faces = response.data          
        })
        .catch(e => {
          this.errors.push(e)
        })
    },
    computed: {    
      totalFace() {
        return this.faces.length
      }
    }
  }
</script>
